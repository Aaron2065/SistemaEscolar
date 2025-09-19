using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolData.DTOs;
using SchoolData.Models;
using SchoolService.Services.Interfaces;


namespace SchoolService.Services.Implementations
{
    public class ClassService : IClassService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public ClassService(
                ApplicationDbContext context 
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassReadDTO>> GetAllAsync()
        {
            return await _context.Classes
                .Select(c => new ClassReadDTO
                {
                    IdClass = c.IdClass,
                    ClassName = c.ClassName,
                    Active  = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<ClassReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Classes
                .FirstOrDefaultAsync(x => x.IdClass == id);

            if (c == null)
                throw new KeyNotFoundException("Clase no encontrado");

            return new ClassReadDTO
            {
                IdClass = c.IdClass,
                ClassName= c.ClassName,
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(ClassCreateDTO dto)
        {
            var classRoom = new Class
            {
                IdClass= dto.IdClass,
                ClassName = dto.ClassName
            };

            await _context.Classes.AddAsync(classRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ClassCreateDTO dto)
        {
            var classRom = await _context.Classes.FindAsync(id);
            if (classRom == null)
                throw new KeyNotFoundException("Clase no encontrado");

            classRom.IdClass = dto.IdClass;
            classRom.ClassName = dto.ClassName;
            classRom.IsDeleted = dto.Deleted;
            classRom.HighSystem = dto.HighSystem;
            classRom.IsActive = dto.Active;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var classRom = await _context.Classes.FindAsync(id);
            if (classRom != null)
            {
                _context.Classes.Remove(classRom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
