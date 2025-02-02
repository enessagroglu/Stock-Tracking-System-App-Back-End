using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }
    }
}