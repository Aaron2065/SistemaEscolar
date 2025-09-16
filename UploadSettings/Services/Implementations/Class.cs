using Microsoft.Extensions.Options;
using SchoolData;
using SchoolService.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class Class
    {
        //Inyectar el Servicio
        ApplicationDbContext _context;
        private Class(ApplicationDbContext context )
        {
            _context = context;

        }
    }
}
