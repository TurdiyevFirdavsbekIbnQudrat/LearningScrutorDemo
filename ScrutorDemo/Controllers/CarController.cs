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
        public IActionResult UserCreate(Car user)
        {
            return Ok(_repository.Create(user));
        }

        public IActionResult UserGetAll()
        {
            return Ok(_repository.GetAll());
        }
    }
}
