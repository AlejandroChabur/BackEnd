using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface ILoansRepository
    {
        Task<Loans> GetLoansByIdAsync(int id);
        Task<IEnumerable<Loans>> GetAllLoansAsync();
        Task CreateLoansAsync(Loans loan);
        Task UpdateLoansAsync(Loans loan);
        Task DeleteLoansAsync(int id);
    }
    public class LoansRepository : ILoansRepository
    {
        private readonly TestDbContext _context;

        public LoansRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loans>> GetAllLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.User) // Incluye el usuario asociado
                .Include(l => l.BooksXLoans) // Incluye la relación con BooksXLoans
                .ToListAsync();
        }

        public async Task<Loans> GetLoansByIdAsync(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.User) // Incluye el usuario asociado
                .Include(l => l.BooksXLoans) // Incluye la relación con BooksXLoans
                .FirstOrDefaultAsync(l => l.IdLoans == id);

            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with ID {id} not found.");
            }

            return loan; // Devuelve la instancia del préstamo encontrado
        }

        public async Task CreateLoansAsync(Loans loan)
        {
            try
            {
                await _context.Loans.AddAsync(loan);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al crear el préstamo: {e.Message}");
                throw; // Vuelve a lanzar la excepción después de registrar el error
            }
        }

        public async Task UpdateLoansAsync(Loans loan)
        {
            // Busca el préstamo existente
            var existingLoan = await _context.Loans.FindAsync(loan.IdLoans);

            if (existingLoan != null)
            {
                // Solo actualiza las propiedades necesarias
                existingLoan.LoanDate = loan.LoanDate;
                existingLoan.ReturnDate = loan.ReturnDate;
                existingLoan.User = loan.User; // Actualiza la relación con el usuario

                // Guarda los cambios
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Loan with ID {loan.IdLoans} not found.");
            }
        }

        public async Task DeleteLoansAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Loan with ID {id} not found.");
            }
        }
    }
}
