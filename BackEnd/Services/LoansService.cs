using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class LoansService
    {
        private readonly LoansRepository _loansRepository;

        public LoansService(LoansRepository loansRepository)
        {
            _loansRepository = loansRepository;
        }

        // Obtener un préstamo por ID
        public async Task<Loans> GetLoanByIdAsync(int id)
        {
            return await _loansRepository.GetLoanByIdAsync(id);
        }

        // Crear un nuevo préstamo
        public async Task CreateLoanAsync(Loans loan)
        {
            await _loansRepository.CreateLoanAsync(loan);
        }

        // Obtener todos los préstamos
        public async Task<IEnumerable<Loans>> GetAllLoansAsync()
        {
            return await _loansRepository.GetAllLoansAsync();
        }

        // Actualizar un préstamo
        public async Task UpdateLoanAsync(Loans loan)
        {
            await _loansRepository.UpdateLoanAsync(loan);
        }

        // Eliminar un préstamo
        public async Task DeleteLoanAsync(int id)
        {
            await _loansRepository.DeleteLoanAsync(id);
        }
    }
}
