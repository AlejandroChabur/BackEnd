using BackEnd.Model;
using BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    //public interface IReportsService
    //{
    //    Task<IEnumerable<Reports>> GetAllReportsAsync();
    //    Task<Reports> GetReportByIdAsync(int id);
    //    Task CreateReportAsync(Reports report);
    //    Task UpdateReportAsync(Reports report);
    //    Task DeleteReportAsync(int id);
    //}

    public class ReportsService 
    {
        private readonly ReportsRepository _reportsRepository;

        public ReportsService(ReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<IEnumerable<Reports>> GetAllReportsAsync()
        {
            return await _reportsRepository.GetAllReportsAsync();
        }

        public async Task<Reports> GetReportByIdAsync(int id)
        {
            return await _reportsRepository.GetReportByIdAsync(id);
        }

        public async Task CreateReportAsync(Reports report)
        {
            await _reportsRepository.CreateReportAsync(report);
        }

        public async Task UpdateReportAsync(Reports report)
        {
            await _reportsRepository.UpdateReportAsync(report);
        }

        public async Task DeleteReportAsync(int id)
        {
            await _reportsRepository.DeleteReportAsync(id);
        }
    }
}
