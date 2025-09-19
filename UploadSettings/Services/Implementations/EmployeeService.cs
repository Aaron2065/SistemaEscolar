using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;
using SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetAllAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeReadDTO
                {
                    IdEmployee = e.IdEmployee,
                    Name = e.Name,
                    BornDate = e.BornDate
                })
                .ToListAsync();
        }

        public async Task<EmployeeReadDTO> GetByIdAsync(int id)
        {
            var e = await _context.Employees.FindAsync(id);
            if (e == null)
                throw new KeyNotFoundException("Empleado no encontrado");

            return new EmployeeReadDTO
            {
                IdEmployee = e.IdEmployee,
                Name = e.Name,
                BornDate = e.BornDate
            };
        }

        public async Task AddAsync(EmployeeCreateDTO dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                BornDate = dto.BornDate
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EmployeeCreateDTO dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new KeyNotFoundException("Empleado no encontrado");

            employee.Name = dto.Name;
            employee.BornDate = dto.BornDate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetEmployeesWithTeachersAsync()
        {
            return await _context.Employees
                .Include(e => e.teachers)
                .Select(e => new EmployeeReadDTO
                {
                    IdEmployee = e.IdEmployee,
                    Name = e.Name,
                    BornDate = e.BornDate
                    // puedes agregar un conteo si quieres:
                    // TeachersCount = e.teachers.Count()
                })
                .ToListAsync();
        }
    }
}
