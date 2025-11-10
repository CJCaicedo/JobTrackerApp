// ---------------------------------------------------------
// File: JobApplicationReadDto.cs
// Description: This file defines what information is shown
// when viewing a job application in the app.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------

namespace JobTrackerApp.Dtos
{
    // This class represents how a job application looks when
    // it’s displayed in the app or shared through the API.
    public class JobApplicationReadDto
    {
        // The number that identifies this job application.
        public int Id { get; set; }

        // The name of the company where the application was sent.
        public string Company { get; set; }

        // The title of the position that was applied for.
        public string JobTitle { get; set; }

        // The current situation of the job application 
        // (Applied, Interviewing, Offer, or Rejected).
        public ApplicationStatus Status { get; set; }

        // The kind of position (for example, Full-time or Contract).
        public EmploymentType EmploymentType { get; set; }

        // A short summary or description about the company or job.
        public string Description { get; set; }

        // A link to the company’s website or the job posting.
        public string WebsiteLink { get; set; }

        // A link to the résumé used for this job application.
        public string ResumeUrl { get; set; }

        // A link to the cover letter used for this job application.
        public string CoverLetter { get; set; }

        // The offered or expected salary for the job.
        public decimal? Salary { get; set; }

        // The date when the job application was submitted.
        public DateTime DateApplied { get; set; } = DateTime.UtcNow;

        // The name of the person contacted at the company.
        public string ContactPerson { get; set; }

        // The email address of the contact person.
        public string ContactEmail { get; set; }

        // The date when this job record was created in the app.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    // Lists the possible stages of a job application.
    public enum ApplicationStatus
    {
        Applied,
        Interviewing,
        Offer,
        Rejected
    }

    // Lists the different types of work that can be offered.
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
