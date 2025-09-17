using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolData.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [Route("api/v1/Class")]
    [ApiController]

    public class ClassController : ControllerBase
    {
        private readonly IClassService _Class;

        public ClassController(IClassService Class)
        {
            _Class = Class;
        }

        //Obtener todas las materias
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _Class.GetAllAsync();
            return Ok(result);
        }

        //Listar x Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _Class.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new { message = "La clase no existe" });
            }

            return Ok(result);
        }

        //Crear
        [HttpPost]
        [Consumes("multipart/forma-data")]
        public async Task<IActionResult> Create([FromForm] ClassCreateDTO createDTO)
        {
            try
            {
                await _Class.AddAsync(createDTO);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createDTO.IdCurse }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al crear la marca {ex.Message}" });
            }
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] ClassCreateDTO classCreateDTO)
        {
            if (Id == classCreateDTO.IdClass)
            {
                return BadRequest(new { message = "El Id de la clase no coincide con el Id de la clase" });
            }

            try
            {
                await _Class.UpdateAsync(Id, classCreateDTO);
                return NoContent();
                //Operacion exitosa
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar la clase: {ex.Message}" });  // Retorna 400 Bad Request con un mensaje de error.
            }

        }

        //Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Exist = await _Class.GetByIdAsync(id);
                if (Exist == null)
                {
                    return NotFound(new { message = "Clase no encontrada" });    
                }

                await _Class.DeleteAsync(id);
                return NoContent();                                                 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = $"Error al eliminar la clase: {ex.Message}"
                    });
            }
        }
    }
}
