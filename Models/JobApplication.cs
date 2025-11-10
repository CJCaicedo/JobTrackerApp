// ---------------------------------------------------------
// File: JobApplication.cs
// Description: This file defines what a job application looks like.
// It includes company information, job details, and contact data.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace JobTrackerApp.Models
{
    // This class represents a single job application.
    // It stores all the important information about the job,
    // the company, and the person who was contacted.
    public class JobApplication
    {
        // A unique number that identifies each job application.
        public int Id { get; set; }

        // The name of the company where the person applied.
        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        // The name of the position or role that was applied for.
        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        // The current situation of the application 
        // (Applied, Interviewing, Offer, or Rejected).
        public ApplicationStatus Status { get; set; }

        // The type of job (Full-time, Part-time, Contract, etc.).
        public EmploymentType EmploymentType { get; set; }

        // A short description of the company or the job itself.
        public string Description { get; set; }

        // A link to the company’s website or the job posting.
        [Url]
        public string WebsiteLink { get; set; }

        // A link to the résumé used in this application.
        [Url]
        public string ResumeUrl { get; set; }

        // A link to the cover letter sent for this application.
        [Url]
        public string CoverLetter { get; set; }

        // The salary offered or expected for the position.
        [Range(0, 800000)]
        public decimal? Salary { get; set; }

        // The date when the person applied for this job.
        [Required]
        public DateTime DateApplied { get; set; } = DateTime.UtcNow;

        // The name of the person contacted at the company.
        [MaxLength(100)]
        public string ContactPerson { get; set; }

        // The email of the person contacted at the company.
        [EmailAddress]
        [MaxLength(100)]
        public string ContactEmail { get; set; }

        // The date when this job record was created in the system.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    // The possible stages a job application can be in.
    public enum ApplicationStatus
    {
        Applied,
        Interviewing,
        Offer,
        Rejected
    }

    // The types of employment a job can have.
    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Contract,
        Internship,
        Seasonal,
        Temporary
    }
}
