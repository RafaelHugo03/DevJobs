using DevJobs.Data;
using DevJobs.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.Repositories
{
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private readonly DataContext _context;

        public JobVacancyRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(JobVacancy jobVacancy)
        {
            _context.Add(jobVacancy);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var toDelete = _context.JobVacancies.FirstOrDefault(x => x.Id == id);
            var applicationToDelete = _context.JobApplications.FirstOrDefault(x => x.JobVacancyId == id);
            _context.Remove(toDelete);
            _context.Remove(applicationToDelete);
            _context.SaveChanges();
        }

        public List<JobVacancy> GetAll()
        {
            return _context.JobVacancies.AsNoTracking().ToList();
        }

        public JobVacancy GetById(int id)
        {
            return _context.JobVacancies
                .Include(x => x.Applications)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(JobVacancy jobVacancy)
        {
            _context.Update(jobVacancy);
            _context.SaveChanges();
        }
    }
}
