using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolService.DTOs;
using SchoolData.Models;
using SchoolService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class StudentCourseService : IStudentCourseService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public StudentCourseService(
                ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentCourseReadDTO>> GetAllAsync()
        {
            return await _context.StudentCourses
                .Include(c => c.Students)
                .Include(c => c.Courses)
                .Select(c => new StudentCourseReadDTO
                {
                    IdCourse = c.IdCource,
                    IdStudent = c.IdStudent,
                    NameStudent = $"{c.IdStudent} - {c.Students.Name}",
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<StudentCourseReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.StudentCourses
                .FirstOrDefaultAsync(x => x.IdStudent == id);

            if (c == null)
                throw new KeyNotFoundException("Pago no encontrado");

            return new StudentCourseReadDTO
            {
                IdCourse = c.IdCource,
                IdStudent = c.IdStudent,
                NameStudent = $"{c.IdStudent} - {c.Students.Name}",
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(StudentCourseCreateDTO dto)
        {
            var studentc = new StudentCourse
            {
                IdStudentCourse = dto.IdCourse,
                IdStudent = dto.IdStudent
            };

            await _context.StudentCourses.AddAsync(studentc);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, StudentCourseCreateDTO dto)
        {
            var paytype = await _context.StudentCourses.FindAsync(id);
            if (paytype == null)
                throw new KeyNotFoundException("Estudiante y Curso no encontrado");

            dto.IdStudent = dto.IdStudent;
            dto.IdCourse = dto.IdCourse;
            dto.Active = dto.Active;
            dto.Deleted = dto.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var studCurse = await _context.StudentCourses.FindAsync(id);
            if (studCurse != null)
            {
                _context.StudentCourses.Remove(studCurse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
