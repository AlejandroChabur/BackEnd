using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly FormatsService _formatsService;

        public FormatsController(FormatsService formatsService)
        {
            _formatsService = formatsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Formats>> GetFormatById(int id)
        {
            var format = await _formatsService.GetFormatByIdAsync(id);
            if (format == null)
            {
                return NotFound();
            }
            return Ok(format);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formats>>> GetAllFormats()
        {
            var formats = await _formatsService.GetAllFormatsAsync();
            return Ok(formats);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFormat([FromBody] Formats format)
        {
            await _formatsService.CreateFormatAsync(format);
            return CreatedAtAction(nameof(GetFormatById), new { id = format.Id }, format);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFormat(int id, [FromBody] Formats format)
        {
            if (id != format.Id)
            {
                return BadRequest();
            }
            await _formatsService.UpdateFormatAsync(format);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFormat(int id)
        {
            await _formatsService.DeleteFormatAsync(id);
            return NoContent();
        }
    }
}
