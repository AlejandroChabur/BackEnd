using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<People>>> GetAllPeople()
        {
            var people = await _peopleService.GetAllPeopleAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<People>> GetPersonById(int id)
        {
            var person = await _peopleService.GetPeopleByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePerson([FromBody] People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _peopleService.CreatePeopleAsync(people);

            return CreatedAtAction(nameof(GetPersonById), new { id = people.Id }, people);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] People people)
        {
            if (id != people.Id)
            {
                return BadRequest();
            }

            var existingPerson = await _peopleService.GetPeopleByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            await _peopleService.UpdatePeopleAsync(people);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var existingPerson = await _peopleService.GetPeopleByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            await _peopleService.DeletePeopleAsync(id);
            return NoContent();
        }
    }
}
