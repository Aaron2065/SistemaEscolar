using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [Route("api/v1/StudentCurse")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _StudentCourseService;

        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _StudentCourseService = studentCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _StudentCourseService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _StudentCourseService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(StudentCourseCreateDTO dto)
        {
            await _StudentCourseService.AddAsync(dto);
            return Ok(new { message = "Estudiante - Curso creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentCourseCreateDTO dto)
        {
            await _StudentCourseService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _StudentCourseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
