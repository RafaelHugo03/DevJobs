using DevJobs.Entities;

namespace DevJobs.Repositories
{
    public interface IJobVacancyRepository
    {
        List<JobVacancy> GetAll();
        JobVacancy GetById(int id);
        void Create(JobVacancy jobVacancy);
        void Update(JobVacancy jobVacancy);
        void delete(int id);
    }
}
