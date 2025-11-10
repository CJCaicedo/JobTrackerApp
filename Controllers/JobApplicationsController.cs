// ---------------------------------------------------------
// File: JobApplicationsControllee.cs
// Description: Controller that exposes CRUD operations for 
//              managing job applications through RESTful API endpoints.
// Author: Cindy Johana Caicedo
// ---------------

using Microsoft.AspNetCore.Mvc;
using JobTrackerApp.Models;
using JobTrackerApp.Data;
using AutoMapper;
using JobTrackerApp.Dtos;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobTrackerApp.Controllers
{
    //API controller responsible for handling all job application operations:
    /// creating, updating, partially updating, and deleting records.
    [ApiController]
    [Route("api/jobapplications")]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationRepository _repository;
        private readonly IMapper _mapper;
        
    /// Initializes the controller with the repository and mapper dependencies.
        public JobApplicationsController(IJobApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

 // ---------------------------------------------------------
// GET: api/jobapplications
// Description: Shows all job applications.
// ---------------------------------------------------------
        [HttpGet]
        public ActionResult<IEnumerable<JobApplication>> GetAllJobsApplications()
        {
            var jobApplicationItems = _repository.GetAllJobApplications();
            return Ok(_mapper.Map<IEnumerable<JobApplicationReadDto>>(jobApplicationItems));
        }

// ---------------------------------------------------------
// GET: api/jobapplications/{id}
// Description: View the details of a specific job application.
// ---------------------------------------------------------
        [HttpGet("{id}", Name = "GetJobApplicationById")]
        public ActionResult<JobApplicationReadDto> GetJobApplicationById(int id)
        {
            var jobApplicationItem = _repository.GetJobApplicationById(id);
            if (jobApplicationItem != null)
            {
                return Ok(_mapper.Map<JobApplicationReadDto>(jobApplicationItem));
            }
            else
            {
                return NotFound();
            }

        }
// ---------------------------------------------------------
// POST: api/jobapplications
// Description: Create and save a new job Application
// ---------------------------------------------------------
        [HttpPost]
        public ActionResult<JobApplicationReadDto> CreateJobApplication(JobApplicationCreateDto jobApplicationCreateDto)
        {
            var jobapplicationModel = _mapper.Map<JobApplication>(jobApplicationCreateDto);
            _repository.CreateJobApplication(jobapplicationModel);
            _repository.SaveChanges();

            var JobApplicationReadDto = _mapper.Map<JobApplicationReadDto>(jobapplicationModel);

            //Indicates that the new job application was created(201) and provides its location(route).
            return CreatedAtRoute(nameof(GetJobApplicationById), new { Id = JobApplicationReadDto.Id }, JobApplicationReadDto);

        }

// ---------------------------------------------------------
// PUT: api/jobapplications/{id}
// Description: Updates an existing job application.
// ---------------------------------------------------------
        [HttpPut("{id}")]
        public ActionResult UpdateJobApplication(int id, JobApplicationUpdateDto jobApplicationUpdateDto)
        {
            var jobApplicacionModelFromRepo = _repository.GetJobApplicationById(id);
            if (jobApplicacionModelFromRepo == null)
            {
                return NotFound();
            }

            // Map updated fields into the existing database record.
            //(Save the new values to the existing job application in the system.)
            _mapper.Map(jobApplicationUpdateDto, jobApplicacionModelFromRepo);

            _repository.UpdateJobApplication(jobApplicacionModelFromRepo);

            _repository.SaveChanges();

            // Confirms the update completed successfully, returns an empty response.
            return NoContent();
        }

        // ---------------------------------------------------------
        // PATCH: api/jobapplications/{id}
        // Description: Lets you update certain fields or 
        // an existing job application without replacing the whole record.
        // ---------------------------------------------------------
        [HttpPatch("{id}")]
        public ActionResult PartialJobApplicationUpdate(int id, JsonPatchDocument<JobApplicationUpdateDto> patchDoc)
        {
            var jobApplicacionModelFromRepo = _repository.GetJobApplicationById(id);

            if (jobApplicacionModelFromRepo == null)
            {
                return NotFound();
            }
            // Make and Work on a separate copy to apply changes without affecting the original data.
            var jobApplicationToPatch = _mapper.Map<JobApplicationUpdateDto>(jobApplicacionModelFromRepo);
            patchDoc.ApplyTo(jobApplicationToPatch, ModelState);

            if (!TryValidateModel(jobApplicationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // Update the stored job application with the patched changes.
            _mapper.Map(jobApplicationToPatch, jobApplicacionModelFromRepo);

            _repository.UpdateJobApplication(jobApplicacionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }
        
// ---------------------------------------------------------
// DELETE: api/jobapplications/{id}
// Description: Deletes a sepecific job application.
// ---------------------------------------------------------

        [HttpDelete("{id}")]
        public ActionResult DeleteJobApplication(int id)
        {
            var jobApplicacionModelFromRepo = _repository.GetJobApplicationById(id);

            if (jobApplicacionModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteJobApplication(jobApplicacionModelFromRepo);
            _repository.SaveChanges();
            
            return NoContent();
        }


    }
}