using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories;
using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return null;
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            await _categoryRepository.AddAsync(category);
            categoryDto.Id = category.Id;
            return categoryDto;
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryDto.Id);
            if (category == null)
                throw new Exception("Category not found");
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
