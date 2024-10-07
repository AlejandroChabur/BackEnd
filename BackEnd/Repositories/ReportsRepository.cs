using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    //public interface IReportsRepository
    //{
    //    Task<IEnumerable<Reports>> GetAllReportsAsync();
    //    Task<Reports> GetReportByIdAsync(int id);
    //    Task CreateReportAsync(Reports report);
    //    Task UpdateReportAsync(Reports report);
    //    Task DeleteReportAsync(int id);
    //}
    public class ReportsRepository
    {
        private readonly TestDbContext _context;

        public ReportsRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reports>> GetAllReportsAsync()
        {
            return await _context.Reports
               .Include(a => a.Loans)
               .Where(a => !a.IsDelete)
               .ToListAsync();
        }

        public async Task<Reports> GetReportByIdAsync(int id)
        {
            var report = await _context.Reports
                .Include(a => a.Loans)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (report == null)
            {
                throw new KeyNotFoundException($"Report with ID {id} not found.");
            }

            return report; // Devolver la instancia del informe encontrado
        }

        public async Task CreateReportAsync(Reports report)
        {
            // Busca el préstamo existente
            var loan = await _context.Loans
                .FindAsync(report.IdLoan); // Asegúrate de que estás usando el ID correcto

            if (loan == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Préstamo no encontrado");
            }

            // Asigna el préstamo encontrado al nuevo registro de Reports
            report.Loans = loan;

            // Ahora agrega el nuevo registro de Reports
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Reports report)
        {
            var existingReport = await _context.Reports.FindAsync(report.Id);

            if (existingReport != null)
            {
                existingReport.IdLoan = report.IdLoan;
                existingReport.Comment = report.Comment;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Report with ID {report.Id} not found.");
            }
        }

        public async Task DeleteReportAsync(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report != null)
            {
                report.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
