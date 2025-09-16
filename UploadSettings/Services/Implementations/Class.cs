using Microsoft.Extensions.Options;
using SchoolData;
using SchoolData.DTOs;
using SchoolService.Services.Implementations;
using SchoolService.Services.Interfaces;
using SchoolService.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class Class : IClass
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        private Class(
                ApplicationDbContext context 
            )
        {
            _context = context;
        }

        public Task AddAsync(ClassCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassReadDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClassReadDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, ClassCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ClassReadDTO>> IGenericService<ClassCreateDTO, ClassReadDTO, ClassCreateDTO>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ClassReadDTO> IGenericService<ClassCreateDTO, ClassReadDTO, ClassCreateDTO>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
