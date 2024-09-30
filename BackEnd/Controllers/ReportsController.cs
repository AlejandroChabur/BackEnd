using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Reports>>> GetAllReports()
        {
            var reports = await _reportsService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reports>> GetReportById(int id)
        {
            var report = await _reportsService.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReport([FromBody] Reports report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _reportsService.CreateReportAsync(report);
            return CreatedAtAction(nameof(GetReportById), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateReport(int id, [FromBody] Reports report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }

            var existingReport = await _reportsService.GetReportByIdAsync(id);
            if (existingReport == null)
            {
                return NotFound();
            }

            await _reportsService.UpdateReportAsync(report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var existingReport = await _reportsService.GetReportByIdAsync(id);
            if (existingReport == null)
            {
                return NotFound();
            }

            await _reportsService.DeleteReportAsync(id);
            return NoContent();
        }
    }
}

