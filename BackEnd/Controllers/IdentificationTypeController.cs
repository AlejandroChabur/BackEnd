using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IdentificationTypeService _identificationTypeService;

        public IdentificationTypeController(IdentificationTypeService identificationTypeService)
        {
            _identificationTypeService = identificationTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationTypeById(int id)
        {
            var identificationType = await _identificationTypeService.GetIdentificationTypeByIdAsync(id);
            if (identificationType == null)
            {
                return NotFound();
            }
            return Ok(identificationType);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationType>>> GetAllIdentificationTypes()
        {
            var identificationTypes = await _identificationTypeService.GetAllIdentificationTypesAsync();
            return Ok(identificationTypes);
        }

        [HttpPost]
        public async Task<ActionResult> CreateIdentificationType([FromBody] IdentificationType identificationType)
        {
            await _identificationTypeService.CreateIdentificationTypeAsync(identificationType);
            return CreatedAtAction(nameof(GetIdentificationTypeById), new { id = identificationType.Id }, identificationType);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIdentificationType(int id, [FromBody] IdentificationType identificationType)
        {
            if (id != identificationType.Id)
            {
                return BadRequest();
            }
            await _identificationTypeService.UpdateIdentificationTypeAsync(identificationType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIdentificationType(int id)
        {
            await _identificationTypeService.DeleteIdentificationTypeAsync(id);
            return NoContent();
        }
    }
}

