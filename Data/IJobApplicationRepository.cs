// ---------------------------------------------------------
// File: IJobApplicationRepository.cs
// Description: This file defines what actions can be done 
// with job applications (like view, add, edit, or delete).
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------

using JobTrackerApp.Models;

namespace JobTrackerApp.Data
{

// This interface lists the main actions that can be done 
// with job applications.

    public interface IJobApplicationRepository
    {
        // Saves all recent changes made to the job applications.
        bool SaveChanges();
        // Gets all job applications that have been added.
        IEnumerable<JobApplication> GetAllJobApplications();

        // Finds a single job application using its unique number.
        JobApplication GetJobApplicationById(int id);

        // Adds a new job application to the list.
        void CreateJobApplication(JobApplication jap);

        // Updates the information for an existing job application.
        void UpdateJobApplication(JobApplication jap);

        // Removes a job application from the list.
        void DeleteJobApplication(JobApplication jap);


    }
}