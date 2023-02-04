using Business_Logic;
using Fluent_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

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
                
                var trainer=_logic.GetTrainers();
                if (trainer != null)
                    return Ok(trainer);
                else
                    return BadRequest("Sorry buddy No records present");
                
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromHeader]string email, [FromBody]Models.Trainer trainer)
        {
            try
            {
                if(!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateTrainer(email, trainer);
                    return Ok(trainer);
                }
                else
                {
                    return BadRequest("Something Wrong,Its not updated");
                }
            }
            catch(Exception ex)
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
                    var del = _logic.RemoveTrainers(email);
                    if (del != null)
                        return Ok(del);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please insert valid Email Id");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add_Trainer")]
        public IActionResult AddTra([FromBody]Models.Trainer trainer)
        {
            try
            {
                var t = _logic.AddTrainers(trainer);
                return Created("Add", t); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
