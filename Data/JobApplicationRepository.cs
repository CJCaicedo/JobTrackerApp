// ---------------------------------------------------------
// File: JobApplicationRepository.cs
// Description: This file provides examples of job applications 
// and shows how information about jobs could be added, found, 
// or removed in the system.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------
using System.ComponentModel;
using JobTrackerApp.Models;

namespace JobTrackerApp.Data
{
    // This class handles the actions related to job applications.
    // Note: This version was originally created as example data for testing.
    public class JobApplicationRepository : IJobApplicationRepository
    {
        // Finds and returns one job application using its number (ID).
        public JobApplication GetJobApplicationById(int id)
        {
            // This is an example job. In a real case, it would come from a database.
            return new JobApplication
            {
                Id = 0,
                Company = "Siesa",
                JobTitle = "Software developer",
                Status = ApplicationStatus.Applied,
                EmploymentType = EmploymentType.FullTime,
                Description = "It's an industry company based in North Carolina",
                WebsiteLink = "",
                ResumeUrl = "",
                CoverLetter = "",
                Salary = 75000.00m,
                DateApplied = DateTime.Parse("2023-01-01"),
                ContactPerson = "",
                ContactEmail = ""
            };


        }

        // Returns a list with a few example job applications.
        public IEnumerable<JobApplication> GetAllJobApplications()
        {
             // Here we have three example job applications.
            // They are used to show what the data will look like.

            var JobApplications = new List<JobApplication>
            {
                new JobApplication
            {
                Id = 0,
                Company = "Siesa",
                JobTitle = "Software developer",
                Status = ApplicationStatus.Applied,
                EmploymentType = EmploymentType.FullTime,
                Description = "It's an industry company based in North Carolina",
                WebsiteLink = "",
                ResumeUrl = "",
                CoverLetter = "",
                Salary = 75000.00m,
                DateApplied = DateTime.Parse("2025-08-01"),
                ContactPerson = "",
                ContactEmail = ""
            },
            new JobApplication
            {
                Id = 1,
                Company = "Comcast",
                JobTitle = "Solutions Architect",
                Status = ApplicationStatus.Applied,
                EmploymentType = EmploymentType.FullTime,
                Description = "company based in center city philadelphia,focused in telecommunications, and entertainment conglomerate",
                WebsiteLink = "",
                ResumeUrl = "",
                CoverLetter = "",
                Salary = 95000.00m,
                DateApplied = DateTime.Parse("2025-08-08"),
                ContactPerson = "",
                ContactEmail = ""
            },
            new JobApplication
            {
                Id = 2,
                Company = "Meta",
                JobTitle = "Senior Software Developer",
                Status = ApplicationStatus.Applied,
                EmploymentType = EmploymentType.FullTime,
                Description = "It's a tech company based in Seattle",
                WebsiteLink = "",
                ResumeUrl = "",
                CoverLetter = "",
                Salary = 150000.00m,
                DateApplied = DateTime.Parse("2025-09-20"),
                ContactPerson = "",
                ContactEmail = ""
            }
            };

            return JobApplications;
        }

        // Saves any recent changes.
        // (Not ready yet — this will be done when the database is connected.)
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
        // Adds a new job application to the list.
        // (Not ready yet — will work with the database later.)
        public void CreateJobApplication(JobApplication jap)
        {
            throw new NotImplementedException();
        }
        // Updates an existing job application.
        // (Not ready yet — will work with the database later.)
        public void UpdateJobApplication(JobApplication jap)
        {
            throw new NotImplementedException();
        }
        // Deletes a job application from the list.
        // (Not ready yet — will work with the database later.)
        public void DeleteJobApplication(JobApplication jap)
        {
            throw new NotImplementedException();
        }
    }
}