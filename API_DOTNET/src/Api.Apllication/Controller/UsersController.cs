
using System.Net;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Apllication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll ()
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

        public async Task<ActionResult> Get(Guid id)
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
        
        public async Task<ActionResult> Delete(Guid id)
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
        [HttpPost]
        public async Task<ActionResult> Post ([FromServices] IUserService _service, [FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result);
                } else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromServices] IUserService _service, [FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}