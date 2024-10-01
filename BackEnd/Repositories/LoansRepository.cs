using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class LoansRepository
    {
        private readonly TestDbContext _context;

        public LoansRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener un préstamo por ID
        public async Task<Loans> GetLoanByIdAsync(int id)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with ID {id} not found.");
            }
            return loan;
        }

        // Crear un nuevo préstamo
        public async Task CreateLoanAsync(Loans loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los préstamos
        public async Task<IEnumerable<Loans>> GetAllLoansAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        // Actualizar un préstamo
        public async Task UpdateLoanAsync(Loans loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        // Eliminar un préstamo
        public async Task DeleteLoanAsync(int id)
        {
            var loan = await GetLoanByIdAsync(id);
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}
