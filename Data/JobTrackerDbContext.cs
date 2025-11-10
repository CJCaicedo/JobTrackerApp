// ---------------------------------------------------------
// File: JobTrackerDbContext.cs
// Description: This file connects the app to the database and
// tells it to keep track of job applications.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------
using JobTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerApp.Data
{
    // This class connects the application to the database.
    // It tells the system what kind of information (like job applications)
    // will be stored and managed.
    public class JobTrackerDbContext : DbContext
    {
        // This part sets up the connection details to the database.
        // The information about the connection is sent here when the app starts.
        public JobTrackerDbContext(DbContextOptions<JobTrackerDbContext> options) : base(options)
        {

        }
        // This represents the list or table of job applications in the database.
        public DbSet<JobApplication> JobApplications { get; set; }
        
    }
}