using DevJobs.Entities;
using DevJobs.Model;
using DevJobs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : Controller
    {
        private readonly IJobVacancyRepository _repository;

        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }
       
        // Get api/job-vacancies
        [HttpGet]
        public IActionResult Get()
        {
            var jobs = _repository.GetAll();
            return Ok(jobs);
        }
        // Get api/job-vacancies/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var job = _repository.GetById(id);
            if (job == null) 
                return NotFound();

            return Ok(job);
        }
        // POST api/job-vacancies
        ///<summary>
        /// Cadastrar uma vaga de emprego.
        /// </summary>
        /// <remarks>
        ///   {
        ///   "title": "Vaga .NET Jr",
        ///   "description": "Vaga para uma grande empresa.",
        ///   "company": "LuisDev",
        ///   "isRemote": true,
        ///   "salaryRange": "3000-5000"
        ///   }
        /// </remarks>
        /// <param name="model">Dados de Vaga</param>
        /// <returns>Objeto recém criado.</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model) 
        {
            if (model == null) return BadRequest();

            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            _repository.Create(jobVacancy);

            return CreatedAtAction(
                "GetById",
                new { id = jobVacancy.Id },
                jobVacancy);
        }
        // Put api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id,UpdateJobVacancyInputModel model) 
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null) return NotFound();

            jobVacancy.Update(model.Title, model.Description);

            _repository.Update(jobVacancy);

            return Ok();
                
        }
        // Delete api/job-vacancies/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null) return NotFound();

            _repository.delete(id);

            return NoContent();
        }
    }
}
