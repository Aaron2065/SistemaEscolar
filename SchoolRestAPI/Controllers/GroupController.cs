using Microsoft.AspNetCore.Mvc;
using SchoolData.DTOs;
using SchoolService.Services.Interfaces;
using System.Threading.Tasks;

namespace SchoolRestAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Group")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _groupService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _groupService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDTO dto)
        {
            await _groupService.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GroupCreateDTO dto)
        {
            await _groupService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("WithTutorAndCourses")]
        public async Task<IActionResult> GetGroupsWithTutorAndCourses()
        {
            var result = await _groupService.GetGroupsWithTutorAndCoursesAsync();
            return Ok(result);
        }
    }
}
