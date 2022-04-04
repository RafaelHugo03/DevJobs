using DevJobs.Data;
using DevJobs.Entities;
using DevJobs.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    public class JobApplicationsController : Controller
    {
        private readonly DataContext _context;

        public JobApplicationsController(DataContext context)
        {
            _context = context;
        }
        // Post api/job-vacancies/4/applications
        [HttpPost]
        public IActionResult Create(int id, AddJobApplicationsInputModel model)
        {
            var jobVacancy = _context.JobVacancies.FirstOrDefault(x => x.Id == id);
            if (jobVacancy == null) return NotFound();

            var application = new JobApplication(
                model.ApplicantName,
                model.ApplicantEmail,
                id
            );

            _context.JobApplications.Add(application);
            _context.SaveChanges();

            return Ok();
        }
    }
}
