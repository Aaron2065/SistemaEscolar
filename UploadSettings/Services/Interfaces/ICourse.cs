using SchoolService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Interfaces
{
    public interface ICourseService : IGenericService<CourseCreateDTO, CourseReadDTO, CourseCreateDTO>
    {
        Task<IEnumerable<CourseReadDTO>> GetCoursesByGroupAsync(int groupId);
    }
}
