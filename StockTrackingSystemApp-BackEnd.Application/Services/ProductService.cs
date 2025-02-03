using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories;
using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            // Manuel mapping: Domain modelden DTO'ya dönüştürme
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryId = p.CategoryId,
                DepotId = p.DepotId
            });
            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return null;
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                DepotId = product.DepotId
            };
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            // Yeni domain nesnesine dönüştürme
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
                DepotId = productDto.DepotId
            };

            await _productRepository.AddAsync(product);
            // EF Core, product.Id'yi atadıysa, bunu DTO'ya aktar.
            productDto.Id = product.Id;
            return productDto;
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);
            if (product == null)
                throw new Exception("Product not found");

            // Güncelleme işlemi
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.CategoryId = productDto.CategoryId;
            product.DepotId = productDto.DepotId;

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
