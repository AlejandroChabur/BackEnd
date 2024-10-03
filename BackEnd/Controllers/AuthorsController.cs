using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Services;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsServices _authorsService;

        // Constructor para inyectar el servicio de autores
        public AuthorsController(AuthorsServices authorsService)
        {
            _authorsService = authorsService;
        }

        // Obtener todos los autores
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Authors>>> GetAllAuthors()
        {
            var authors = await _authorsService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // Obtener un autor por ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Authors>> GetAuthorById(int id)
        {
            var author = await _authorsService.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // Crear un nuevo autor
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAuthor([FromBody] Authors author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authorsService.CreateAuthorAsync(author);

            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        // Actualizar un autor existente
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Authors author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var existingAuthor = await _authorsService.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            // Actualiza los campos necesarios en el autor
            existingAuthor.Country = author.Country;
            // Otros campos pueden actualizarse aquí.

            await _authorsService.UpdateAuthorAsync(existingAuthor);
            return NoContent();
        }

        // Eliminar un autor por su ID
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var existingAuthor = await _authorsService.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            await _authorsService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
