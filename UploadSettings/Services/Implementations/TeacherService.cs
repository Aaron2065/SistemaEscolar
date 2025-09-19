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
    public class TeacherService : ITeacherService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public TeacherService(
                ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherReadDTO>> GetAllAsync()
        {
            return await _context.Teachers
                .Include(c => c.Employee)
                .Select(c => new TeacherReadDTO
                {
                    
                    IdEmployee = c.EmployeeId,
                    GroupDisplayName = $"{c.EmployeeId} - {c.Employee.Name}",
                    IdTeacher = c.IdTeacher,
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<TeacherReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Teachers
                .FirstOrDefaultAsync(x => x.IdTeacher == id);

            if (c == null)
                throw new KeyNotFoundException("Docente no encontrado");

            return new TeacherReadDTO
            {
                IdEmployee = c.EmployeeId,
                GroupDisplayName = $"{c.EmployeeId} - {c.Employee.Name}",
                IdTeacher = c.IdTeacher,
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(TeacherCreateDTO dto)
        {
            var teacher = new Teacher
            {
                IdTeacher = dto.IdTeacher,
                EmployeeId  = dto.IdEmployee

            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TeacherCreateDTO dto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new KeyNotFoundException("Docente no encontrado");

            teacher.EmployeeId = dto.IdEmployee;
            dto.Active = dto.Active;
            dto.Deleted = dto.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paytype = await _context.Teachers.FindAsync(id);
            if (paytype != null)
            {
                _context.Teachers.Remove(paytype);
                await _context.SaveChangesAsync();
            }
        }
    }
}
