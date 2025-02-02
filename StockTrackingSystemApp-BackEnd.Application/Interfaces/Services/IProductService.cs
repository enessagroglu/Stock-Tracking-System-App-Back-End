using StockTrackingSystemApp_BackEnd.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task UpdateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
    }

}