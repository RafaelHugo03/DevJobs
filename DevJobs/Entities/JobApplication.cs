using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevJobs.Entities
{
    [Table("Applicants")]
    public class JobApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required, MaxLength(40)]
        [Column("ApplicantName", TypeName = "NVARCHAR")]
        public string ApplicantName { get; private set; }
        [Required, MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        [Column("ApplicantEmail", TypeName = "NVARCHAR")]
        public string ApplicantEmail { get; private set; }
        [Required]
        [ForeignKey("JobVacabcyId")]
        public int JobVacancyId { get; private set; }

        public JobApplication(string applicantName, string applicantEmail, int jobVacancyId)
        {
            ApplicantName = applicantName;
            ApplicantEmail = applicantEmail;
            JobVacancyId = jobVacancyId;
        }
    }
}
