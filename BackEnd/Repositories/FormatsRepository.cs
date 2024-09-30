using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class FormatsRepository
    {
        private readonly TestDbContext _context;

        public FormatsRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener un formato por ID
        public async Task<Formats> GetFormatByIdAsync(int id)
        {
            var format = await _context.Formats.FirstOrDefaultAsync(f => f.Id == id);
            if (format == null)
            {
                throw new KeyNotFoundException($"Format with ID {id} not found.");
            }
            return format;
        }

        // Crear un nuevo formato
        public async Task CreateFormatAsync(Formats format)
        {
            await _context.Formats.AddAsync(format);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los formatos
        public async Task<IEnumerable<Formats>> GetAllFormatsAsync()
        {
            return await _context.Formats.ToListAsync();
        }

        // Actualizar un formato
        public async Task UpdateFormatAsync(Formats format)
        {
            _context.Formats.Update(format);
            await _context.SaveChangesAsync();
        }

        // Eliminar un formato
        public async Task DeleteFormatAsync(int id)
        {
            var format = await GetFormatByIdAsync(id);
            _context.Formats.Remove(format);
            await _context.SaveChangesAsync();
        }
    }
}
