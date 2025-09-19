using Microsoft.EntityFrameworkCore;
using SchoolData;

using SchoolData.Models;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class PayTypeServices : IPayTypeServices
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public PayTypeServices(
                ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<PayTypeReadDTO>> GetAllAsync()
        {
            return await _context.PayTypes
                .Select(c => new PayTypeReadDTO
                {
                    IdPayType = c.IdPayType,
                    Description = c.TypeDescription,
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<PayTypeReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.PayTypes
                .FirstOrDefaultAsync(x => x.IdPayType == id);

            if (c == null)
                throw new KeyNotFoundException("Pago no encontrado");

            return new PayTypeReadDTO
            {
                IdPayType = c.IdPayType,
                Description = c.TypeDescription,
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(PayTypeCreateDTO dto)
        {
            var paytype = new PayType
            {
                //IdPayType = dto.IdPayType,
                TypeDescription = dto.Description
                
            };

            await _context.PayTypes.AddAsync(paytype);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, PayTypeCreateDTO dto)
        {
            var paytype = await _context.PayTypes.FindAsync(id);
            if (paytype == null)
                throw new KeyNotFoundException("Tipo de pago no encontrado");

            dto.Description = dto.Description;
            dto.Active = dto.Active;
            dto.Deleted = dto.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paytype = await _context.PayTypes.FindAsync(id);
            if (paytype != null)
            {
                _context.PayTypes.Remove(paytype);
                await _context.SaveChangesAsync();
            }
        }
    }
}
