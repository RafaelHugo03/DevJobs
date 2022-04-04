using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevJobs.Entities
{
    [Table("Vacancies")]
    public class JobVacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required, MaxLength(40)]
        [Column("Title", TypeName = "NVARCHAR")]
        public string Title { get; private set; }
        [Required, MaxLength(2000)]
        [Column("Description", TypeName = "NVARCHAR")]
        public string Description { get; private set; }
        [Required, MaxLength(20)]
        [Column("Company", TypeName = "NVARCHAR")]
        public string  Company { get; private set; }
        [Required]
        public bool IsRemote { get; private set; }
        [Required, MaxLength(20)]
        [Column("SalaryRange", TypeName = "NVARCHAR")]
        public string SalaryRamge { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<JobApplication> Applications { get; private set; }

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
