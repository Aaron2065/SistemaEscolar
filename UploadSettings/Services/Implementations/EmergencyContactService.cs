using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolData.DTOs;
using SchoolData.Models;
using SchoolService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private readonly ApplicationDbContext _context;

        public EmergencyContactService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmergencyContactReadDTO>> GetAllAsync()
        {
            return await _context.EmergencyContacts
                .Select(c => new EmergencyContactReadDTO
                {
                    IdContact = c.IdContact,
                    IdStudent = c.IdStudent
                })
                .ToListAsync();
        }

        public async Task<EmergencyContactReadDTO> GetByIdAsync(int id)
        {
            var contact = await _context.EmergencyContacts.FindAsync(id);
            if (contact == null)
                throw new KeyNotFoundException("Contacto de emergencia no encontrado");

            return new EmergencyContactReadDTO
            {
                IdContact = contact.IdContact,
                IdStudent = contact.IdStudent
            };
        }

        public async Task AddAsync(EmergencyContactCreateDTO dto)
        {
            var contact = new EmergencyContact
            {
                IdStudent = dto.IdStudent
            };

            await _context.EmergencyContacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EmergencyContactCreateDTO dto)
        {
            var contact = await _context.EmergencyContacts.FindAsync(id);
            if (contact == null)
                throw new KeyNotFoundException("Contacto de emergencia no encontrado");

            contact.IdStudent = dto.IdStudent;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.EmergencyContacts.FindAsync(id);
            if (contact != null)
            {
                _context.EmergencyContacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmergencyContactReadDTO>> GetContactsWithStudentAsync()
        {
            return await _context.EmergencyContacts
                .Include(c => c.Students)
                .Select(c => new EmergencyContactReadDTO
                {
                    IdContact = c.IdContact,
                    IdStudent = c.IdStudent,
                    StudentName = c.Students.Name
                })
                .ToListAsync();
        }
    }
}
