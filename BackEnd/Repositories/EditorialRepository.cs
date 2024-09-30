using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class EditorialsRepository
    {
        private readonly TestDbContext _context;

        public EditorialsRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener una editorial por ID
        public async Task<Editorials> GetEditorialByIdAsync(int id)
        {
            var editorial = await _context.Editorials.FirstOrDefaultAsync(e => e.Id == id);
            if (editorial == null)
            {
                throw new KeyNotFoundException($"Editorial with ID {id} not found.");
            }
            return editorial;
        }

        // Crear una nueva editorial
        public async Task CreateEditorialAsync(Editorials editorial)
        {
            await _context.Editorials.AddAsync(editorial);
            await _context.SaveChangesAsync();
        }

        // Obtener todas las editoriales
        public async Task<IEnumerable<Editorials>> GetAllEditorialsAsync()
        {
            return await _context.Editorials.ToListAsync();
        }

        // Actualizar una editorial
        public async Task UpdateEditorialAsync(Editorials editorial)
        {
            _context.Editorials.Update(editorial);
            await _context.SaveChangesAsync();
        }

        // Eliminar una editorial
        public async Task DeleteEditorialAsync(int id)
        {
            var editorial = await GetEditorialByIdAsync(id);
            _context.Editorials.Remove(editorial);
            await _context.SaveChangesAsync();
        }
    }
}

