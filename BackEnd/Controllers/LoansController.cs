using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LoansService _loansService;

        public LoansController(LoansService loansService)
        {
            _loansService = loansService;
        }

        // GET: api/loans/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Loans>> GetLoanById(int id)
        {
            var loan = await _loansService.GetLoanByIdAsync(id);
            if (loan == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra el préstamo
            }
            return Ok(loan); // Retorna 200 y el préstamo encontrado
        }

        // GET: api/loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loans>>> GetAllLoans()
        {
            var loans = await _loansService.GetAllLoansAsync();
            return Ok(loans); // Retorna 200 y todos los préstamos
        }

        // POST: api/loans
        [HttpPost]
        public async Task<ActionResult> CreateLoan(Loans loan)
        {
            await _loansService.CreateLoanAsync(loan);
            return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan); // Retorna 201 y el nuevo préstamo
        }

        // PUT: api/loans
        [HttpPut]
        public async Task<ActionResult> UpdateLoan(Loans loan)
        {
            await _loansService.UpdateLoanAsync(loan);
            return NoContent(); // Retorna 204 si el préstamo se actualiza correctamente
        }

        // DELETE: api/loans/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            await _loansService.DeleteLoanAsync(id);
            return NoContent(); // Retorna 204 si el préstamo se elimina correctamente
        }
    }
}
