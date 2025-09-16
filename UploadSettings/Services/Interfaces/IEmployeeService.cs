using SchoolData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Interfaces
{
    public interface IEmployeeService : IGenericService<EmployeeCreateDTO, EmployeeReadDTO, EmployeeCreateDTO>

    {
        Task<IEnumerable<EmployeeReadDTO>> GetEmployeesWithTeachersAsync();
    }

}
