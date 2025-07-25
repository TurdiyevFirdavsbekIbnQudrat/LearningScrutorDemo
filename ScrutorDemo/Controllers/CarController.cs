using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScrutorDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IGeneral<Car> _repository;
        public CarController(IGeneral<Car> repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public OkObjectResult UserCreate(Car user)
        {
            return Ok(_repository.Create(user));
        }
        [HttpGet]
        public OkObjectResult UserGetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet]
        public IActionResult UserIfExistGetAll()
        {
            return Ok(_repository.IfExistGetAll());
        }
    }
}
