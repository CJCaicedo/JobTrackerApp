// ---------------------------------------------------------
// File: SqlJobApplicationRepo.cs
// Description: This file connects the app with the real database
// and manages everything related to saving, finding, updating, 
// and deleting job applications.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------
using JobTrackerApp.Models;

namespace JobTrackerApp.Data
{
    // This class is responsible for communicating with the database.
    // It saves, updates, finds, or deletes job applications.
    public class SqlJobApplicationRepo : IJobApplicationRepository
    {
        private readonly JobTrackerDbContext _context;
        // This brings in the database connection when the app starts.
        public SqlJobApplicationRepo(JobTrackerDbContext context)
        {
            _context = context;
        }
        // Adds a new job application to the database.
        public void CreateJobApplication(JobApplication jap)
        {
            if (jap == null)
            {
                throw new ArgumentNullException(nameof(jap));
            }
            // Adds the new job application to be saved later.
            _context.JobApplications.Add(jap);
        }
        // Removes a job application from the database.
        public void DeleteJobApplication(JobApplication jap)
        {
            if (jap == null)
            {
                throw new ArgumentNullException(nameof(jap));
            }
            // Marks the selected job application for removal.
            _context.JobApplications.Remove(jap);
        }
        // Returns a list of all job applications saved in the database.
        public IEnumerable<JobApplication> GetAllJobApplications()
        {
            return _context.JobApplications.ToList();
        }
        // Finds a specific job application by its ID number.
        // If it doesn't exist, a clear message is shown.
        public JobApplication GetJobApplicationById(int id)
        {
            return _context.JobApplications.FirstOrDefault(a => a.Id == id)
            ?? throw new InvalidOperationException($"JobApplication with ID {id} was not found.");
           
        }
        // Saves all recent changes to the database.
        public bool SaveChanges()
        {
            // Returns true if everything was saved correctly.
            return (_context.SaveChanges() >= 0);
        }
        
        // Updates an existing job application.
        // (Right now it doesn’t need extra code because the system
        // already tracks the changes automatically.)
        public void UpdateJobApplication(JobApplication jap)
        {
        
        }
    }
}