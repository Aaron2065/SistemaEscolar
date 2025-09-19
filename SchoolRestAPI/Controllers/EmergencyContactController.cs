using Microsoft.AspNetCore.Mvc;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;
using System.Threading.Tasks;

namespace SchoolRestAPI.Controllers
{
    [ApiController]
    [Route("api/v1/EmergencyContacts")]
    public class EmergencyContactsController : ControllerBase
    {
        private readonly IEmergencyContactService _contactService;

        public EmergencyContactsController(IEmergencyContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _contactService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmergencyContactCreateDTO dto)
        {
            await _contactService.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmergencyContactCreateDTO dto)
        {
            await _contactService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("WithStudent")]
        public async Task<IActionResult> GetContactsWithStudent()
        {
            var result = await _contactService.GetContactsWithStudentAsync();
            return Ok(result);
        }
    }
}
