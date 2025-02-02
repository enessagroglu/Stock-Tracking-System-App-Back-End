using Microsoft.AspNetCore.Mvc;
using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var created = await _categoryService.CreateCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}