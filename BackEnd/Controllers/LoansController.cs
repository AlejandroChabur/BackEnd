using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoansServices _loansService;

        public LoansController(ILoansServices loansService)
        {
            _loansService = loansService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Loans>>> GetAllLoans()
        {
            var loans = await _loansService.GetAllLoansAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Loans>> GetLoanById(int id)
        {
            var loan = await _loansService.GetLoansByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateLoan([FromBody] Loans loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _loansService.CreateLoansAsync(loan);

            return CreatedAtAction(nameof(GetLoanById), new { id = loan.IdLoans }, loan);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLoan(int id, [FromBody] Loans loan)
        {
            var existingLoan = await _loansService.GetLoansByIdAsync(id);
            if (existingLoan == null)
            {
                return NotFound();
            }

            await _loansService.UpdateLoansAsync(loan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var existingLoan = await _loansService.GetLoansByIdAsync(id);
            if (existingLoan == null)
            {
                return NotFound();
            }

            await _loansService.DeleteLoansAsync(id);
            return NoContent();
        }
    }
}
