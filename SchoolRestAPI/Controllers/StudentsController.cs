using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _studentService.GetByIdAsync(id);

            if (brand == null)
            {
                return NotFound(new { message = "El alumno no existe" });     // Respuesta HTTP 404 Not Found con un mensaje
            }

            return Ok(brand);                                                 // Retorna 200 OK con el producto encontrado.
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] StudentCreateDTO brandDTO)
        {
            try
            {
                var createdBrand = await _studentService.AddAsync2(brandDTO);
                return CreatedAtAction(
                    nameof(GetById),
                    new {

                        id = createdBrand.IdStudent
                        //id = createdBrand.IdStudent,
                        //name = createdBrand.Name,
                        //active = createdBrand.Active,
                        //deleted = createdBrand.Deleted,
                        //high = createdBrand.HighSystem
                        //age = createdBrand.Age
                    },
                    brandDTO);


            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al crear el estudiante: {ex.Message}" });
            }
        }
    }
}
