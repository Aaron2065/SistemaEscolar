using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolData.DTOs;
using SistemaEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Interfaces
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
                .Include(c => c.Teachers)
                    .ThenInclude(t => t.Employee) // IMPORTANTE: incluir Employee para obtener el nombre
                .Select(c => new CourseReadDTO
                {
                    IdCourse = c.IdCourse,
                    IdGroup = c.IdGroup,
                    GroupDisplayName = $"{c.Group.Grade}-{c.Group.GroupClass}", // Concatenamos para mostrar
                    IdClass = c.IdClass,
                    ClassName = c.Class.ClassName,
                    TeacherId = c.TeacherId,
                    TeacherName = c.Teachers.Employee.Name
                })
                .ToListAsync();
        }


        public async Task<CourseReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Courses
                .Include(c => c.Group)
                .Include(c => c.Class)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(x => x.IdCourse == id);

            if (c == null)
                throw new KeyNotFoundException("Curso no encontrado");

            return new CourseReadDTO
            {
                IdCourse = c.IdCourse,
                IdGroup = c.IdGroup,
                GroupDisplayName = $"{c.Group.Grade}-{c.Group.GroupClass}", // Concatenamos para mostrar
                IdClass = c.IdClass,
                ClassName = c.Class.ClassName,
                TeacherId = c.TeacherId,
                TeacherName = c.Teachers.Employee.Name
            };
        }

        public async Task AddAsync(CourseCreateDTO dto)
        {
            var course = new Course
            {
                IdGroup = dto.IdGroup,
                IdClass = dto.IdClass,
                TeacherId = dto.TeacherId
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
            course.TeacherId = dto.TeacherId;

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
                .Include(c => c.Teachers)
                .Select(c => new CourseReadDTO
                {
                    IdCourse = c.IdCourse,
                    IdGroup = c.IdGroup,
                    GroupDisplayName = $"{c.Group.Grade}-{c.Group.GroupClass}", // Concatenamos para mostrar
                    IdClass = c.IdClass,
                    ClassName = c.Class.ClassName,
                    TeacherId = c.TeacherId,
                    TeacherName = c.Teachers.Employee.Name
                })
                .ToListAsync();
        }
    }
}
