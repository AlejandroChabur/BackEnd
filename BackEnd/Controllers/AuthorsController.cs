using Microsoft.AspNetCore.Mvc; // Asegúrate de tener este espacio de nombres
using BackEnd.Model;
using BackEnd.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly TestDbContext _context;

        public AuthorsController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            return author; // Devuelve la instancia del autor encontrado
        }
    }
}

