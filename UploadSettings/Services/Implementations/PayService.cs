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
    public class PayService : IPayService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        public PayService(
                ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<PayReadDTO>> GetAllAsync()
        {
            return await _context.Pays
                .Include(c => c.Students)
                .Include(C => C.PayTypes)
                .Select(c => new PayReadDTO
                {
                    IdPay = c.IdPay,
                    IdStudent = c.IdStudent,
                    Amount = c.Amount,
                    IdPayType = c.IdPayType,
                    InscriptionDate = c.InscriptionDate,
                    GroupPayType = $"{c.IdPayType} - {c.Students.Name}",
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<PayReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Pays
                .Include(c => c.PayTypes)
                .FirstOrDefaultAsync(x => x.IdPay == id);

            if (c == null)
                throw new KeyNotFoundException("Pago no encontrado");

            return new PayReadDTO
            {
                IdPay = c.IdPay,
                IdStudent = c.IdStudent,
                Amount = c.Amount,
                IdPayType = c.IdPayType,
                InscriptionDate = c.InscriptionDate,
                GroupPayType = $"{c.IdPayType} - {c.Students.Name}",
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(PayCreateDTO dto)
        {
            var pay = new Pay
            {
                IdPay = dto.IdPay,
                IdStudent = dto.IdStudent,
                InscriptionDate = dto.InscriptionDate,
                Amount = dto.Amount,
                IdPayType = dto.IdPayType
            };

            await _context.Pays.AddAsync(pay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, PayCreateDTO dto)
        {
            var pay = await _context.Pays.FindAsync(id);
            if (pay == null)
                throw new KeyNotFoundException("Curso no encontrado");

            pay.IdStudent = dto.IdStudent;
            pay.Amount = dto.Amount;
            pay.InscriptionDate = dto.InscriptionDate;
            pay.IdPayType = dto.IdPayType;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pay = await _context.Pays.FindAsync(id);
            if (pay != null)
            {
                _context.Pays.Remove(pay);
                await _context.SaveChangesAsync();
            }
        }
    }
}
