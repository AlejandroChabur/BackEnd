using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly EditorialsService _EditorialsService;

        public EditorialsController(EditorialsService EditorialsService)
        {
            _EditorialsService = EditorialsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editorials>> GetEditorialById(int id)
        {
            var editorial = await _EditorialsService.GetEditorialByIdAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return Ok(editorial);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorials>>> GetAllEditorials()
        {
            var editorials = await _EditorialsService.GetAllEditorialsAsync();
            return Ok(editorials);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEditorial([FromBody] Editorials editorial)
        {
            await _EditorialsService.CreateEditorialAsync(editorial);
            return CreatedAtAction(nameof(GetEditorialById), new { id = editorial.Id}, editorial);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEditorial(int id, [FromBody] Editorials editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest();
            }
            await _EditorialsService.UpdateEditorialAsync(editorial);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEditorial(int id)
        {
            await _EditorialsService.DeleteEditorialAsync(id);
            return NoContent();
        }
    }
}
