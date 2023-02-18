using Business_Logic;
using Fluent_API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        public IActionResult Get([FromHeader]string email)
        {
            try
            {
                Log.Information("---------- Fetching Work Experience Details -------------");
                var sk = repo.GetWork(email);
                if (sk != null)
                    return Ok(sk);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update_Work_Details")]
        public IActionResult Put([FromHeader] string email, [FromHeader] string Company_Name, [FromBody] Models.WorkE work)
        {
            try
            {
                Log.Information("---------- Updating Work Experience details -------------");
                int Id = trepo.IdFetcher(email);
                var ed = repo.UpdateWorkExp(Id, email, Company_Name, work);
                if (ed != null)
                    return Ok(ed);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (UserException u)
            {
                return BadRequest(u.Message);
            }
            catch (Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete_Work_Details")]

        public IActionResult Delete([FromHeader] string email, [FromHeader] string Company_Name)
        {
            try
            {
                Log.Information("---------- Deleting Work Details -------------");
                int id = trepo.IdFetcher(email);
                var sk = repo.DeleteWork(id, Company_Name);
                if (sk != null) return Ok(sk);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add_Work_Details")]

        public IActionResult Add([FromHeader] string email, [FromBody] Models.WorkE work)
        {
            try
            {
                Log.Information("---------- Adding Work Details -------------");
                int id = trepo.IdFetcher(email);
                var sk = repo.AddWork(id, work);
                if (sk != null) return Ok(sk);
                else
                    return BadRequest("Its not added you got an error ");
            }
            catch (UserException u)
            {
                return BadRequest(u.Message);
            }
            catch (Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }
    }
}
