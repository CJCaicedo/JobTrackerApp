// ---------------------------------------------------------
// File: JobApplicationUpdateDto.cs
// Description: This file defines the details that can be 
// changed when editing an existing job application.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace JobTrackerApp.Dtos
{
    // This class describes the fields that can be updated
    // for a job application. It’s used when editing or correcting
    // information that was already added before.
    public class JobApplicationUpdateDto
    {
        // The name of the company related to the application.
        public string Company { get; set; }

        // The title of the job that is being applied for.
        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        // The current situation of the job application 
        // (Applied, Interviewing, Offer, or Rejected).
        public ApplicationStatus Status { get; set; }

        // The kind of work offered (for example, Full-time or Contract).
        public EmploymentType EmploymentType { get; set; }

        // A short description of the company or the job position.
        public string Description { get; set; }

        // A link to the company’s website or job posting.
        [Url]
        public string WebsiteLink { get; set; }

        // A link to the résumé used for this job.
        [Url]
        public string ResumeUrl { get; set; }

        // A link to the cover letter used for this job.
        [Url]
        public string CoverLetter { get; set; }

        // The offered or expected salary for the position.
        [Range(0, 800000)]
        public decimal? Salary { get; set; }

        // The name of the contact person at the company.
        [Required]
        public string ContactPerson { get; set; }

        // The email address of the contact person.
        [EmailAddress]
        [MaxLength(100)]
        public string ContactEmail { get; set; }
        // The date when this information was last created or updated.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
