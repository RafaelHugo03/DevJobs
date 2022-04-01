using DevJobs.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set;}
    }
}
