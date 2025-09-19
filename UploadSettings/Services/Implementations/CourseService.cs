using Microsoft.EntityFrameworkCore;
using SchoolData;

using SchoolData.Models;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolService.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseReadDTO>> GetAllAsync()
        {            
            return await _context.Courses
                .Include(c => c.Group)
                .Include(c => c.Class)
                .Select(c => new CourseReadDTO
                {
                    IdCourse = c.IdCourse,
                    IdGroup = c.IdGroup,
                    GroupDisplayName = $"{c.Group.Grade}-{c.Group.GroupClass}", // Concatenamos para mostrar
                    IdClass = c.IdClass,
                    ClassName = c.Class.ClassName
                })
                .ToListAsync();
        }


        public async Task<CourseReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Courses
                .Include(c => c.Group)
                .Include(c => c.Class)
                .FirstOrDefaultAsync(x => x.IdCourse == id);

            if (c == null)
                throw new KeyNotFoundException("Curso no encontrado");

            return new CourseReadDTO
            {
                IdCourse = c.IdCourse,
                IdGroup = c.IdGroup,
                GroupDisplayName = $"{c.Group.Grade}-{c.Group.GroupClass}", // Concatenamos para mostrar
                IdClass = c.IdClass,
                ClassName = c.Class.ClassName
            };
        }

        public async Task AddAsync(CourseCreateDTO dto)
        {
            var course = new Course
            {
                IdGroup = dto.IdGroup,
                IdClass = dto.IdClass
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CourseCreateDTO dto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                throw new KeyNotFoundException("Curso no encontrado");

            course.IdGroup = dto.IdGroup;
            course.IdClass = dto.IdClass;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseReadDTO>> GetCoursesByGroupAsync(int groupId)
        {
            return await _context.Courses
                .Where(c => c.IdGroup == groupId)
                .Include(c => c.Group)
                .Include(c => c.Class)
                .Select(c => new CourseReadDTO
                {
                    IdCourse = c.IdCourse,
                    IdGroup = c.IdGroup,
                    GroupDisplayName = $"{c.Group.Grade}-{c.Group.GroupClass}", // Concatenamos para mostrar
                    IdClass = c.IdClass,
                    ClassName = c.Class.ClassName
                })
                .ToListAsync();
        }
    }
}
