using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using Fluent_API;
using Serilog;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalController : ControllerBase
    {
        IAddLogic repo;
        ITrainerRepo trepo;

        public AdditionalController(IAddLogic _repo, ITrainerRepo _trepo)
        {
           repo = _repo;
           trepo = _trepo;
        }
        [HttpGet("Fetch_Additional_Details")]
        public IActionResult Get([FromHeader] string email)
        {
            try
            {
                Log.Information("---------- Fetching Addtional Details -------------");
                var sk = repo.DisplayAdditional(email);
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

        [HttpPut("Update_Additional_Details")]
        public IActionResult Put([FromHeader] string email, [FromHeader] string Title, [FromBody] Models.Additional ad)
        {
            try
            {
                Log.Information("---------- Updating Additional Details -------------");
                int Id = trepo.IdFetcher(email);
                var ed = repo.UpdateAdditional(Id, email, Title, ad);
                if (ed != null)
                    return Ok(ed);
                else
                    return BadRequest("Sorry buddy No records present");
            }
            catch (Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete_Additional_Details")]

        public IActionResult Delete([FromHeader] string email, [FromHeader] string Title)
        {
            try
            {
                Log.Information("---------- Deleting Additional Details -------------");
                int id = trepo.IdFetcher(email);
                var sk = repo.DeleteAddtional(id, Title);
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

        [HttpPost("Add_Addtional_Details")]

        public IActionResult Add([FromHeader] string email, [FromBody] Models.Additional ad)
        {
            try
            {
                Log.Information("---------- Adding Additional Details -------------");
                int id = trepo.IdFetcher(email);
                var sk = repo.AddAdditional(id, ad);
                if (sk != null) return Ok(sk);
                else
                    return BadRequest("Its not added you got an error ");
            }
            catch (Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }
    }
}
