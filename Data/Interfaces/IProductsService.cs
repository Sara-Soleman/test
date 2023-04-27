using Flash_listings.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Data.Interfaces
{
    public interface IProductsService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync(string lang);
        public Task<ProductDTO> GetProductByIdAsync(int productId, string lang);
        public Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto, string lang);
        public Task<ProductDTO> UpdateProductAsync(int productId, CreateProductDTO updateProductDto, string lang);
        public Task<bool> DeleteProductAsync(int productId);
    }
}
