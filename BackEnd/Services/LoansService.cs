using BackEnd.Model;
using BackEnd.Repositories; // Asegúrate de que esta línea esté aquí
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface ILoansServices
    {
        Task<IEnumerable<Loans>> GetAllLoansAsync();
        Task<Loans> GetLoansByIdAsync(int id);
        Task CreateLoansAsync(Loans loan);
        Task UpdateLoansAsync(Loans loan);
        Task DeleteLoansAsync(int id);
    }

    public class LoansServices : ILoansServices
    {
        private readonly ILoansRepository _loansRepository;

        public LoansServices(ILoansRepository loansRepository)
        {
            _loansRepository = loansRepository;
        }

        public async Task<IEnumerable<Loans>> GetAllLoansAsync()
        {
            return await _loansRepository.GetAllLoansAsync();
        }

        public async Task<Loans> GetLoansByIdAsync(int id)
        {
            return await _loansRepository.GetLoansByIdAsync(id);
        }

        public async Task CreateLoansAsync(Loans loan)
        {
            await _loansRepository.CreateLoansAsync(loan);
        }

        public async Task UpdateLoansAsync(Loans loan)
        {
            await _loansRepository.UpdateLoansAsync(loan);
        }

        public async Task DeleteLoansAsync(int id)
        {
            await _loansRepository.DeleteLoansAsync(id);
        }
    }
}
