using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolService.Services.Interfaces;
using SchoolData.DTOs;

namespace SchoolRestAPI.Controllers
{
    [Route("api/v1/Pay")]
    [ApiController]
    public class PayController : ControllerBase
    {
            private readonly IPayService _PayService;

            public PayController(IPayService payService)
            {
                _PayService = payService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll() =>
                Ok(await _PayService.GetAllAsync());

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id) =>
                Ok(await _PayService.GetByIdAsync(id));

            [HttpPost]
            public async Task<IActionResult> Create(PayCreateDTO dto)
            {
                await _PayService.AddAsync(dto);
                return Ok(new { message = "Pago creado correctamente" });
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, PayCreateDTO dto)
            {
                await _PayService.UpdateAsync(id, dto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _PayService.DeleteAsync(id);
                return NoContent();
            }
        
    }
    }
