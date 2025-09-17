using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolData.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [Route("api/v1/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _TeacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _TeacherService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _TeacherService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateDTO dto)
        {
            await _TeacherService.AddAsync(dto);
            return Ok(new { message = "Docente creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TeacherCreateDTO dto)
        {
            await _TeacherService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _TeacherService.DeleteAsync(id);
            return NoContent();
        }
    }
}

