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
    public class TutorService : ITutorService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public TutorService(
                ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<TutorReadDTO>> GetAllAsync()
        {
            return await _context.Tutors
                .Include(c => c.Employee)
                .Select(c => new TutorReadDTO
                {
                    IdTutor = c.IdTutor,
                    IdEmployee = c.EmployeeId,
                    EmployeeDisplayName = $"{c.EmployeeId} - {c.Employee.Name}",
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<TutorReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Tutors
                .FirstOrDefaultAsync(x => x.IdTutor == id);

            if (c == null)
                throw new KeyNotFoundException("Docente no encontrado");

            return new TutorReadDTO
            {
                IdTutor = c.IdTutor,
                IdEmployee = c.EmployeeId,
                EmployeeDisplayName = $"{c.EmployeeId} - {c.Employee.Name}",
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(TutorCreateDTO dto)
        {
            var teacher = new Teacher
            {
                
                EmployeeId = dto.IdEmployee

            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TutorCreateDTO dto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new KeyNotFoundException("Tutor no encontrado");

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
