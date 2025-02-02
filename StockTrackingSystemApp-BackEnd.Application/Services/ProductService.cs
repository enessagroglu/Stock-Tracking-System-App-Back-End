using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProductAsync(ProductDto productDto)
        {
            throw new System.NotImplementedException();
        }
    }
}