using Business_Logic;
using Fluent_API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ISkills _skills;
        ITrainerRepo irepo;
        public SkillsController(ISkills skill, ITrainerRepo _repo)
        {
            _skills= skill;
            irepo= _repo;
        }

        [HttpGet("Fetch_Skills")]
        public IActionResult GetSkills(string email) 
        {
            try
            {
                Log.Information("---------- Fetching Skills -------------");
                var sk = _skills.GetSkills(email);
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

        [HttpDelete("Delete Skills")]
        
        public IActionResult DeleteSkills([FromHeader]string email, [FromHeader]string Skill_Name)
        {
            try
            {
                Log.Information("---------- Deleting skills -------------");
                int id = irepo.IdFetcher(email);
                var sk = _skills.DeleteSl(id, Skill_Name);
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

        [HttpPost("Add_Skills")]

        public IActionResult Add([FromHeader] string email, [FromHeader] string Skill_Name)
        {
            try
            {
                Log.Information("---------- Adding skills -------------");
                int id = irepo.IdFetcher(email);
                var sk = _skills.AddSkill(id, Skill_Name);
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
    }
}
