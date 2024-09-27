using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditionController : ControllerBase
    {
        private readonly EditionService _editionService;

        public EditionController(EditionService editionService)
        {
            _editionService = editionService;
        }

        // GET: api/edition/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Edition>> GetEditionById(int id)
        {
            var edition = await _editionService.GetEditionByIdAsync(id);
            if (edition == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra la edición
            }
            return Ok(edition); // Retorna 200 y la edición encontrada
        }

        // GET: api/edition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edition>>> GetAllEditions()
        {
            var editions = await _editionService.GetAllEditionsAsync();
            return Ok(editions); // Retorna 200 y todas las ediciones
        }

        // POST: api/edition
        [HttpPost]
        public async Task<ActionResult> CreateEdition(Edition edition)
        {
            await _editionService.CreateEditionAsync(edition);
            return CreatedAtAction(nameof(GetEditionById), new { id = edition.Id }, edition); // Retorna 201 y la nueva edición
        }

        // PUT: api/edition
        [HttpPut]
        public async Task<ActionResult> UpdateEdition(Edition edition)
        {
            await _editionService.UpdateEditionAsync(edition);
            return NoContent(); // Retorna 204 si la edición se actualiza correctamente
        }

        // DELETE: api/edition/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEdition(int id)
        {
            await _editionService.DeleteEditionAsync(id);
            return NoContent(); // Retorna 204 si la edición se elimina correctamente
        }
    }
}
