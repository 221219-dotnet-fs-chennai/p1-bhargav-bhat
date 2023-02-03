using Business_Logic;
using Fluent_API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                var sk = repo.GetEducation(email);
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

        [HttpPut("Update_Education")]
        public IActionResult Put([FromHeader]string email,[FromHeader]string College_Name,[FromBody]Models.Educate educate)
        {
            try
            {
                int Id = trepo.IdFetcher(email);
                var ed = repo.UpdateEdu(Id,email,College_Name, educate);
                if (ed!=null)
                    return Ok(ed);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete Education")]

        public IActionResult Delete([FromHeader] string email, [FromHeader] string College_Name)
        {
            try
            {
                int id = trepo.IdFetcher(email);
                var sk = repo.DeleteEducation(id, College_Name);
                if (sk != null) return Ok(sk);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add Educations")]

        public IActionResult Add([FromHeader] string email, [FromBody] Models.Educate educate)
        {
            try
            {
                int id = trepo.IdFetcher(email);
                var sk = repo.AddEducation(id, educate);
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
