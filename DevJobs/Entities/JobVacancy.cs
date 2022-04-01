namespace DevJobs.Entities
{
    public class JobVacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string  Company { get; set; }
        public bool IsRemote { get; set; }
        public string SalaryRamge { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<JobApplication> Applications { get; set; }

        public JobVacancy(string title, string description, string company, bool isRemote, string salaryRamge)
        {
            Title = title;
            Description = description;
            Company = company;
            IsRemote = isRemote;
            SalaryRamge = salaryRamge;

            CreatedAt = DateTime.Now;
            Applications = new List<JobApplication>();
        }

        public void Update(string title, string description) 
        {
            Title = title;
            Description = description;
        }
    }
}
