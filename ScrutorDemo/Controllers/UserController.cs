using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rhino.Mocks.Constraints;
using ScrutorDemo.Validators;

namespace ScrutorDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGeneral<User> _repository;
        public UserController(IGeneral<User> repository)
        {
            _repository = repository; 
        }

        [HttpPost]
        public IActionResult UserCreate(User user)
        {
            if(ModelState.IsValid)
            {
                return Ok(_repository.Create(user));
            }
            return BadRequest("Some of values is not valid");
        }
        [HttpGet]
        public IActionResult UserGetAll() 
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet]
        public OkObjectResult GetAllIfExist()
        {
            return Ok(_repository.IfExistGetAll());
        }
        [HttpDelete]
        public IActionResult Delete() 
        {
            return Ok(_repository.CleanCache());
        }
    }
}
