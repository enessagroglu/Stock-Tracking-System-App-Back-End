using Microsoft.AspNetCore.Mvc;
using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepotsController : ControllerBase
    {
        private readonly IDepotService _depotService;
        
        public DepotsController(IDepotService depotService)
        {
            _depotService = depotService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var depots = await _depotService.GetAllDepotsAsync();
            return Ok(depots);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var depot = await _depotService.GetDepotByIdAsync(id);
            if (depot == null)
                return NotFound();
            return Ok(depot);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(DepotDto depotDto)
        {
            var created = await _depotService.CreateDepotAsync(depotDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepotDto depotDto)
        {
            if (id != depotDto.Id)
                return BadRequest();
            await _depotService.UpdateDepotAsync(depotDto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _depotService.DeleteDepotAsync(id);
            return NoContent();
        }
    }
}