using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class EditionRepository
    {
        private readonly TestDbContext _context;

        public EditionRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener una edición por ID
        public async Task<Edition> GetEditionByIdAsync(int id)
        {
            var edition = await _context.Editions.FirstOrDefaultAsync(e => e.Id == id);
            if (edition == null)
            {
                throw new KeyNotFoundException($"Edition with ID {id} not found.");
            }
            return edition;
        }

        // Crear una nueva edición
        public async Task CreateEditionAsync(Edition edition)
        {
            await _context.Editions.AddAsync(edition);
            await _context.SaveChangesAsync();
        }

        // Obtener todas las ediciones
        public async Task<IEnumerable<Edition>> GetAllEditionsAsync()
        {
            return await _context.Editions
                .Where(a => !a.IsDelete)
                .ToListAsync();
            
        }

        // Actualizar una edición
        public async Task UpdateEditionAsync(Edition edition)
        {
            _context.Editions.Update(edition);
            await _context.SaveChangesAsync();
        }

        // Eliminar una edición
        public async Task DeleteEditionAsync(int id)
        {
            var edition = await GetEditionByIdAsync(id);
            edition.IsDelete = true;
            await _context.SaveChangesAsync();
        }
    }
}
