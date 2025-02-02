using StockTrackingSystemApp_BackEnd.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task UpdateCategoryAsync(CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}