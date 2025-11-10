// ---------------------------------------------------------
// File: JobApplicationCreateDto.cs
// Description: This file defines the information that must be 
// provided when adding a new job application.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace JobTrackerApp.Dtos
{

    // This class describes the details needed to add a new job application.
    // It includes basic company information, contact details, and dates.
    public class JobApplicationCreateDto
    {

       // The number that identifies this job application.
       public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        // The name of the company where the person applied.
        public string Company { get; set; }
        [Required]
        [MaxLength(100)]
        // The title of the job (for example, “Software Developer”).
        public string JobTitle { get; set; }
        // The current step or situation of the application 
        // (for example, Applied, Interviewing, Offer, or Rejected).
        public ApplicationStatus Status { get; set; }  
        // The type of job (for example, Full-time, Part-time, or Contract).
        public EmploymentType EmploymentType { get; set; }
        // A short description of the company or the job position.
        public string Description { get; set; }
        // A website link for the company or the job posting.
        [Url]
        public string WebsiteLink { get; set; }
        // A link to the résumé that was sent for this job.
        [Url]
        public string ResumeUrl { get; set; }
        [Url]
        // A link to the cover letter that was sent for this job.
        public string CoverLetter { get; set; }
        // The offered or expected salary for the position.
        [Range(0, 800000)]
        public decimal? Salary { get; set; }
        // The date when the job application was submitted.
        [Required]
        public DateTime DateApplied { get; set; } = DateTime.UtcNow;
        // The name of the person contacted at the company.
        [MaxLength(100)]
        public string ContactPerson { get; set; }
        // The email address of the contact person.
        [EmailAddress]
        [MaxLength(100)]
        public string ContactEmail { get; set; }
        // The date when this record was created in the system.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}