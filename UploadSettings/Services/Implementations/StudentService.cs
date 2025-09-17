using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolData.DTOs;
using SchoolData.Models;
using SchoolService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class StudentService : IStudentService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public StudentService(
                ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentReadDTO>> GetAllAsync()
        {
            return await _context.Students
                .Select(c => new StudentReadDTO
                {
                    IdStudent = c.IdStudent,
                    Age = c.Age,
                    Name = c.Name,
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<StudentReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Students
                .FirstOrDefaultAsync(x => x.IdStudent == id);

            if (c == null)
                throw new KeyNotFoundException("Estudiante no encontrado");

            return new StudentReadDTO
            {
                IdStudent = c.IdStudent,
                Name = c.Name,
                Age = c.Age,
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(StudentCreateDTO dto)
        {
            var stud = new Student
            {
                Age = dto.Age,
                Name = dto.Name
            };

            await _context.Students.AddAsync(stud);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, StudentCreateDTO dto)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud == null)
                throw new KeyNotFoundException("Estudiante no encontrado");

            dto.Age = dto.Age;
            dto.Active = dto.Active;
            dto.Deleted = dto.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud != null)
            {
                _context.Students.Remove(stud);
                await _context.SaveChangesAsync();
            }
        }
    }
}
