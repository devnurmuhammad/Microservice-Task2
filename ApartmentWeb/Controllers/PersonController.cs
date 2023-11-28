using Apartment.Application.Services.Persons;
using Apartment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllPersonAsync()
        {
            IList<Person> people = await _personService.GetAllAsync();
            return Ok(people);
        }
    }
}
