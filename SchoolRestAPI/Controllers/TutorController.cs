using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [Route("api/v1/tutor")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _TutorService;

        public TutorController(ITutorService TutorService)
        {
            _TutorService = TutorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _TutorService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _TutorService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(TutorCreateDTO dto)
        {
            await _TutorService.AddAsync(dto);
            return Ok(new { message = "Docente creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TutorCreateDTO dto)
        {
            await _TutorService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _TutorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
