using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicsService _topicsService;

        public TopicsController(ITopicsService topicsService)
        {
            _topicsService = topicsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Topics>>> GetAllTopics()
        {
            var topics = await _topicsService.GetAllTopicsAsync();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Topics>> GetTopicById(int id)
        {
            var topic = await _topicsService.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTopic([FromBody] Topics topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _topicsService.CreateTopicAsync(topic);
            return CreatedAtAction(nameof(GetTopicById), new { id = topic.Id }, topic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] Topics topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            var existingTopic = await _topicsService.GetTopicByIdAsync(id);
            if (existingTopic == null)
            {
                return NotFound();
            }

            await _topicsService.UpdateTopicAsync(topic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var existingTopic = await _topicsService.GetTopicByIdAsync(id);
            if (existingTopic == null)
            {
                return NotFound();
            }

            await _topicsService.DeleteTopicAsync(id);
            return NoContent();
        }
    }
}
