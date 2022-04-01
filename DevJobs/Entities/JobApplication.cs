namespace DevJobs.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public int JobVacancyId { get; set; }

        public JobApplication(string applicantName, string applicantEmail, int jobVacancyId)
        {
            ApplicantName = applicantName;
            ApplicantEmail = applicantEmail;
            JobVacancyId = jobVacancyId;
        }
    }
}
