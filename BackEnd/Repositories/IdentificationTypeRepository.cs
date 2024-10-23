using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class IdentificationTypeRepository
    {
        private readonly TestDbContext _context;

        public IdentificationTypeRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener un tipo de identificación por ID
        public async Task<IdentificationType> GetIdentificationTypeByIdAsync(int id)
        {
            var identificationType = await _context.IdentificationTypes.FirstOrDefaultAsync(it => it.Id == id);
            if (identificationType == null)
            {
                throw new KeyNotFoundException($"IdentificationType with ID {id} not found.");
            }
            return identificationType;
        }

        // Crear un nuevo tipo de identificación
        public async Task CreateIdentificationTypeAsync(IdentificationType identificationType)
        {
            await _context.IdentificationTypes.AddAsync(identificationType);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los tipos de identificación
        public async Task<IEnumerable<IdentificationType>> GetAllIdentificationTypesAsync()
        {
            return await _context.IdentificationTypes
                .Where(a => !a.IsDelete)
                .ToListAsync();
        }

        // Actualizar un tipo de identificación
        public async Task UpdateIdentificationTypeAsync(IdentificationType identificationType)
        {
            _context.IdentificationTypes.Update(identificationType);
            await _context.SaveChangesAsync();
        }

        // Eliminar un tipo de identificación
        public async Task DeleteIdentificationTypeAsync(int id)
        {
            var identificationType = await GetIdentificationTypeByIdAsync(id);
            identificationType.IsDelete = true;
            await _context.SaveChangesAsync();
        }
    }
}
