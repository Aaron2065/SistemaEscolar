using EcommerceREST.Web.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolData;
using SchoolData.Models;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;
using SchoolService.Settings;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class StudentService : IStudentService
    {
        //Inyectar el Servicio
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UploadSettings _uploadSettings;
        public StudentService(
                  ApplicationDbContext context
                , IWebHostEnvironment env
                , IOptions<UploadSettings> uploadSettingsOptions
            )
        {
            _context = context;
            _env = env;
            _uploadSettings = uploadSettingsOptions.Value;
        }

        public async Task<IEnumerable<StudentReadDTO>> GetAllAsync()
        {
            return await _context.Students
                .Select(c => new StudentReadDTO
                {
                    IdStudent = c.IdStudent,
                    Age = c.Age,
                    Name = c.Name,
                    Active = c.IsActive,
                    HighSystem = c.HighSystem,
                    Deleted = c.IsDeleted
                })
                .ToListAsync();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<StudentReadDTO> AddAsync2(StudentCreateDTO studentCreateDTO)
        {
            var urlImagen = await UploadImage(studentCreateDTO.File);

            var student = new Student
            {
                Name = studentCreateDTO.Name,
                FotoUrl = urlImagen
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new StudentReadDTO
            {
                IdStudent = student.IdStudent,
                Name = student.Name,
                Age= student.Age,
                Active = student.IsActive,
                Deleted = student.IsDeleted,
                HighSystem = student.HighSystem
            };
        }

        private async Task<string> UploadImage(IFormFile file)
        {
            ValidateFile(file);

            string _customPath = Path.Combine(Directory.GetCurrentDirectory(), _uploadSettings.UploadDirectory);
            //string _customPath = Path.Combine(_env.WebRootPath, _uploadSettings.UploadDirectory);

            if (!Directory.Exists(_customPath))   // Crear el directorio si no existe
            {
                Directory.CreateDirectory(_customPath);
            }

            // Generar el nombre único del archivo
            var fileName = Path.GetFileNameWithoutExtension(file.FileName)
                            + Guid.NewGuid().ToString()
                            + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_customPath, fileName);

            // Guardar el archivo
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retornar la ruta relativa o completa, según sea necesario
            return $"/{_uploadSettings.UploadDirectory}/{fileName}";
        }

        private void ValidateFile(IFormFile file)
        {
            var permittedExtensions = _uploadSettings.AllowedExtensions
                                 .Split(',')
                                 .Select(e => e.Trim().ToLowerInvariant())
                                 .ToArray();

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            Console.WriteLine($"Archivo subido: {file.FileName}");
            Console.WriteLine($"Extensión detectada: {extension}");
            Console.WriteLine($"Extensiones permitidas: {string.Join(", ", permittedExtensions)}");
            if (!permittedExtensions.Contains(extension))
            {
                throw new NotSupportedException(Messages.Validation.UnSupportedFileType);
            }
        }
        public async Task<StudentReadDTO> GetByIdAsync(int id)
        {
            var c = await _context.Students
                .FirstOrDefaultAsync(x => x.IdStudent == id);

            if (c == null)
                throw new KeyNotFoundException("Estudiante no encontrado");

            return new StudentReadDTO
            {
                IdStudent = c.IdStudent,
                Name = c.Name,
                Age = c.Age,
                Active = c.IsActive,
                HighSystem = c.HighSystem,
                Deleted = c.IsDeleted
            };
        }

        public async Task AddAsync(StudentCreateDTO dto)
        {
            var stud = new Student
            {
                Age = dto.Age,
                Name = dto.Name
            };

            await _context.Students.AddAsync(stud);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, StudentCreateDTO dto)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud == null)
                throw new KeyNotFoundException("Estudiante no encontrado");

            dto.Age = dto.Age;
            dto.Active = dto.Active;
            dto.Deleted = dto.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud != null)
            {
                _context.Students.Remove(stud);
                await _context.SaveChangesAsync();
            }
        }
    }
}
