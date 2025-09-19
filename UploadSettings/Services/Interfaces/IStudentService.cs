using SchoolService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Interfaces
{
    public interface IStudentService : IGenericService<StudentCreateDTO, StudentReadDTO, StudentCreateDTO>
    {
        Task<StudentReadDTO> AddAsync2(StudentCreateDTO dto);
    }
}
