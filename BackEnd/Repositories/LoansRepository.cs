using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

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
            var loan = await _context.Loans
                 .Include(a => a.User)
                .FirstOrDefaultAsync(l => l.Id == id);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with ID {id} not found.");
            }
            return loan;
        }

        // Crear un nuevo préstamo
        public async Task CreateLoanAsync(Loans loan)
        {
            var user = await _context.Users

        .FindAsync(loan.IdUser); // Asegúrate de que estás usando el ID correcto

            if (user == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Usuario no encontrado");
            }

            // Asigna el usuario encontrado al nuevo registro de Loans
            loan.User = user;

            // Ahora agrega el nuevo registro de Loans
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los préstamos
        public async Task<IEnumerable<Loans>> GetAllLoansAsync()
        {
            return await _context.Loans
                 .Include(a => a.User)
                .ToListAsync();
        }

        // Actualizar un préstamo
        public async Task UpdateLoanAsync(Loans loan)
        {
            var existingLoan = await _context.Loans.FindAsync(loan.Id);

            if (existingLoan != null)
            {
                existingLoan.IdUser = loan.IdUser;
                existingLoan.LoanDate = loan.LoanDate;
                existingLoan.ReturnDate = loan.ReturnDate;
       

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {loan.Id} not found.");
            }
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
