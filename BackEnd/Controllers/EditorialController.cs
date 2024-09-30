using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly EditorialsService _editorialsService;

        public EditorialsController(EditorialsService editorialsService)
        {
            _editorialsService = editorialsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editorials>> GetEditorialById(int id)
        {
            var editorial = await _editorialsService.GetEditorialByIdAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return Ok(editorial);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorials>>> GetAllEditorials()
        {
            var editorials = await _editorialsService.GetAllEditorialsAsync();
            return Ok(editorials);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEditorial([FromBody] Editorials editorial)
        {
            await _editorialsService.CreateEditorialAsync(editorial);
            return CreatedAtAction(nameof(GetEditorialById), new { id = editorial.Id }, editorial);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEditorial(int id, [FromBody] Editorials editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest();
            }
            await _editorialsService.UpdateEditorialAsync(editorial);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEditorial(int id)
        {
            await _editorialsService.DeleteEditorialAsync(id);
            return NoContent();
        }
    }
}
