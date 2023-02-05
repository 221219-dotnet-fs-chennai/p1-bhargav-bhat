using Business_Logic;
using Fluent_API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        IEducationLogic repo;
        ITrainerRepo trepo;
        public EducationController(IEducationLogic _repo,ITrainerRepo _trepo)
        {
            repo= _repo;
            trepo= _trepo;
        }

        [HttpGet("Fetch Education Details")]
        public IActionResult Get(string email)
        {
            try
            {
                Log.Information("---------- Fetching Educational Details -------------");
                var sk = repo.GetEducation(email);
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

        [HttpPut("Update_Education")]
        public IActionResult Put([FromHeader]string email,[FromHeader]string College_Name,[FromBody]Models.Educate educate)
        {
            try
            {
                Log.Information("---------- Updating Educational Details -------------");
                int Id = trepo.IdFetcher(email);
                var ed = repo.UpdateEdu(Id,email,College_Name, educate);
                if (ed!=null)
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

        [HttpDelete("Delete Education")]

        public IActionResult Delete([FromHeader] string email, [FromHeader] string College_Name)
        {
            try
            {
                Log.Information("---------- Deleting Educational Details -------------");
                int id = trepo.IdFetcher(email);
                var sk = repo.DeleteEducation(id, College_Name);
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

        [HttpPost("Add Educations")]

        public IActionResult Add([FromHeader] string email, [FromBody] Models.Educate educate)
        {
            try
            {
                Log.Information("---------- Adding Educational details -------------");
                int id = trepo.IdFetcher(email);
                var sk = repo.AddEducation(id, educate);
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
