using BackEnd.Model;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserType>>> GetAllUserTypes()
        {
            var userTypes = await _userTypeService.GetAllUserTypesAsync();
            return Ok(userTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserType>> GetUserTypeById(int id)
        {
            var userType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (userType == null)
            {
                return NotFound();
            }
            return Ok(userType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserType([FromBody] UserType userType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userTypeService.CreateUserTypeAsync(userType);
            return CreatedAtAction(nameof(GetUserTypeById), new { id = userType.Id }, userType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserType(int id, [FromBody] UserType userType)
        {
            if (id != userType.Id)
            {
                return BadRequest();
            }

            var existingUserType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (existingUserType == null)
            {
                return NotFound();
            }

            await _userTypeService.UpdateUserTypeAsync(userType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            var existingUserType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (existingUserType == null)
            {
                return NotFound();
            }

            await _userTypeService.DeleteUserTypeAsync(id);
            return NoContent();
        }
    }
}
