namespace DevJobs.Model
{
    public record AddJobVacancyInputModel(
        string Title,
        string Description,
        string Company,
        bool IsRemote,
        string SalaryRange);
}
