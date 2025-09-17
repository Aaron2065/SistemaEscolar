using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolData.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _courseService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _courseService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDTO dto)
        {
            await _courseService.AddAsync(dto);
            return Ok(new { message = "Curso creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseCreateDTO dto)
        {
            await _courseService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("ByGroup/{groupId}")]
        public async Task<IActionResult> GetByGroup(int groupId) =>
            Ok(await _courseService.GetCoursesByGroupAsync(groupId));
    }
}
