
using System.Net;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Apllication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll ([FromServices] IUserService _service, Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //404
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]

        public async Task<ActionResult> Get([FromServices] IUserService _service, Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //404
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult> Delete([FromServices] IUserService _service, Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //404
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}