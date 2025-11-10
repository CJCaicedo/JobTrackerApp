// ---------------------------------------------------------
// File: JobApplicationsProfile.cs
// Description: This file explains how information is shared 
// between different parts of the app (for example, between the 
// job data in the database and the job data shown on screen).
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------
using AutoMapper;
using JobTrackerApp.Dtos;
using JobTrackerApp.Models;

namespace JobTrackerApp.Profiles
{
    // This class tells the system how to copy and match 
    // information between different objects that represent 
    // a job application.
    public class JobApplicationsProfile : Profile
    {
        // Sets the rules for how job application information 
        // is transferred between the database, the API, and the views.
        public JobApplicationsProfile()
        {
            // From database job to the version shown on screen
            CreateMap<JobApplication, JobApplicationReadDto>();
            // From the update form to the database job
            CreateMap<JobApplicationUpdateDto, JobApplication>();
            // From database job to the update form
            CreateMap<JobApplication, JobApplicationUpdateDto>();
            // From the create form to the database job
            CreateMap<JobApplicationCreateDto, JobApplication>();
        }

    }
}