// ---------------------------------------------------------
// File: JobApplicationUiController.cs
// Description: This file handles everything related to showing,
// adding, editing, and deleting job applications in the website view.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------

using JobTrackerApp.Data;
using JobTrackerApp.Dtos;
using JobTrackerApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;   

namespace JobTrackerApp.Controllers
{

    // This controller is in charge of displaying and managing
    // job applications through the website pages.
    public class JobApplicationUiController : Controller
    {
        private readonly IJobApplicationRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<JobApplicationUiController> _logger;  

        public JobApplicationUiController(
            IJobApplicationRepository repo,
            IMapper mapper,
            ILogger<JobApplicationUiController> logger)   
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

// ---------------------------------------------------------
// Shows the main page with all job applications.
// ---------------------------------------------------------
        public IActionResult Index()
        {
            var jobs = _repo.GetAllJobApplications();
            var jobDtos = _mapper.Map<IEnumerable<JobApplicationReadDto>>(jobs);

            _logger.LogInformation("Loaded {Count} job applications for index view.", jobDtos.Count());

            return View(jobDtos);
        }

// ---------------------------------------------------------
// Shows the page where the user can add a new job.
// ---------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }

// ---------------------------------------------------------
// Saves the new job that the user filled out in the form.
// If something goes wrong, a message is shown instead.
// ---------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobApplicationCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Create called with invalid model state.");
                return View(model);
            }

            try
            {
                var job = _mapper.Map<JobApplication>(model);
                _repo.CreateJobApplication(job);
                _repo.SaveChanges();

                _logger.LogInformation("Created job application for company {Company}", model.Company);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating job application for company {Company}", model.Company);
                ModelState.AddModelError("", "There was a problem saving the job application.");
                return View(model);
            }
        }

// ---------------------------------------------------------
// Shows the page where the user can edit an existing job.
// ---------------------------------------------------------
        public IActionResult Edit(int id)
        {
            var job = _repo.GetJobApplicationById(id);
            if (job == null)
            {
                _logger.LogWarning("Edit GET: job with id {Id} not found.", id);
                return NotFound();
            }

            var dto = _mapper.Map<JobApplicationUpdateDto>(job);
            return View(dto);
        }

// ---------------------------------------------------------
// Updates the information of an existing job application.
// ---------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, JobApplicationUpdateDto model)
        {
            var job = _repo.GetJobApplicationById(id);
            if (job == null)
            {
                _logger.LogWarning("Edit POST: job with id {Id} not found.", id);
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Edit POST: invalid model state for job id {Id}", id);
                return View(model);
            }

            try
            {
                _mapper.Map(model, job);
                _repo.UpdateJobApplication(job);
                _repo.SaveChanges();

                _logger.LogInformation("Updated job application id {Id}", id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating job application id {Id}", id);
                ModelState.AddModelError("", "There was a problem updating this job application.");
                return View(model);
            }
        }

// ---------------------------------------------------------
// Shows the page asking for confirmation before deleting a job.
// ---------------------------------------------------------
        public IActionResult Delete(int id)
        {
            var job = _repo.GetJobApplicationById(id);
            if (job == null)
            {
                _logger.LogWarning("Delete GET: job with id {Id} not found.", id);
                return NotFound();
            }

            var dto = _mapper.Map<JobApplicationReadDto>(job);
            return View(dto);
        }

// ---------------------------------------------------------
// Removes the selected job after the user confirms deletion.
// ---------------------------------------------------------
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var job = _repo.GetJobApplicationById(id);
            if (job == null)
            {
                _logger.LogWarning("Delete POST: job with id {Id} not found.", id);
                return NotFound();
            }

            try
            {
                _repo.DeleteJobApplication(job);
                _repo.SaveChanges();

                _logger.LogInformation("Deleted job application id {Id}", id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting job application id {Id}", id);
                ModelState.AddModelError("", "There was a problem deleting this job application.");
                // Re-show the same page with the message if there was an error.
                var dto = _mapper.Map<JobApplicationReadDto>(job);
                return View("Delete", dto);
            }
        }
    }
}
