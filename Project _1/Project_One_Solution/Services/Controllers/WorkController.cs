using Business_Logic;
using Fluent_API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        IWork repo;
        ITrainerRepo trepo;

        public WorkController(IWork repo, ITrainerRepo trepo)
        {
            this.repo = repo;
            this.trepo = trepo;
        }

        [HttpGet("Fetch_Work_Experience_Details")]
        public IActionResult Get(string email)
        {
            try
            {
                var sk = repo.GetWork(email);
                if (sk != null)
                    return Ok(sk);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update_Work_Details")]
        public IActionResult Put([FromHeader] string email, [FromHeader] string Company_Name, [FromBody] Models.WorkE work)
        {
            try
            {
                int Id = trepo.IdFetcher(email);
                var ed = repo.UpdateWorkExp(Id, email, Company_Name, work);
                if (ed != null)
                    return Ok(ed);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete_Work_Details")]

        public IActionResult Delete([FromHeader] string email, [FromHeader] string Company_Name)
        {
            try
            {
                int id = trepo.IdFetcher(email);
                var sk = repo.DeleteWork(id, Company_Name);
                if (sk != null) return Ok(sk);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add_Work_Details")]

        public IActionResult Add([FromHeader] string email, [FromBody] Models.WorkE work)
        {
            try
            {
                int id = trepo.IdFetcher(email);
                var sk = repo.AddWork(id, work);
                if (sk != null) return Ok(sk);
                else
                    return BadRequest("Its not added you got an error ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
