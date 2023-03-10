using Business_Logic;
using Fluent_API.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerControl : ControllerBase
    {
        ITrainerLogic _logic;
        public TrainerControl(ITrainerLogic logic) 
        {
            _logic= logic;
        }

        [HttpGet("Fetch_Trainers")]
        public IActionResult Get()
        {
            try
            {
                Log.Information("---------- Fetching Trainers -------------");
                var trainer=_logic.GetTrainers();
                if (trainer != null)
                    return Ok(trainer);
                else
                    return BadRequest("Sorry buddy No records present");
                
                
            }
            catch(Exception ex)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromHeader]string email, [FromBody]Models.Trainer trainer)
        {
            try
            {
                Log.Information("---------- Updating Trainer details -------------");
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateTrainer(email, trainer);
                    return Ok(trainer);
                }
                else
                {
                    Log.Information("---------- Exception Handled -------------");
                    return BadRequest("Something Wrong,Its not updated");
                }
            }
            catch (UserException u)
            {
                return BadRequest(u.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("Delete_Trainer")]
        public IActionResult Delete([FromHeader]string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    Log.Information("---------- Deleting Trainer -------------");
                    var del = _logic.RemoveTrainers(email);
                    if (del != null)
                        return Ok(del);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please insert valid Email Id");
            }
            catch(Exception)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest();
            }
        }

        [HttpPost("Add_Trainer")]
        public IActionResult AddTra([FromBody]Models.Trainer trainer)
        {
            try
            {
                Log.Information("---------- Adding Trainer -------------");
                var t = _logic.AddTrainers(trainer);
                return Ok(t);
            }
            catch (InvalidDataException e)
            {
                Log.Information("---------- Exception Handled -------------");
                return BadRequest(e.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Verify")]
        //[EnableCors("MyAllowSpecificOrigins")]
        public IActionResult something([FromHeader] string email, [FromHeader]string password)
        {
            var d=_logic.FetchTrainer(email,password);
            if(d==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(d);
            }
        }

    }
}
