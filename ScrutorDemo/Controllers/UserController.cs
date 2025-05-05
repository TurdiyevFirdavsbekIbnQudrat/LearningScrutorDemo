using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult UserCreate(User user)
        {
            return Ok(_repository.Create(user));
        }

        public IActionResult UserGetAll() 
        {
            return Ok(_repository.GetAll());
        }
    }
}
