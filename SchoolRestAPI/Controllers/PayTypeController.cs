using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolService.DTOs;
using SchoolService.Services.Interfaces;

namespace SchoolRestAPI.Controllers
{
    [Route("api/v1/PayType")]
    [ApiController]
    public class PayTypeController : ControllerBase
    {
        private readonly IPayTypeServices _PayTypeService;

        public PayTypeController(IPayTypeServices payTypeService)
        {
            _PayTypeService = payTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _PayTypeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _PayTypeService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(PayTypeCreateDTO dto)
        {
            await _PayTypeService.AddAsync(dto);
            return Ok(new { message = "Tipo de Pago creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PayTypeCreateDTO dto)
        {
            await _PayTypeService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _PayTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
