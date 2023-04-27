using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flash_listings.Data;
using Flash_listings.Models;
using Flash_listings.Data.ModelDTO;
using Flash_listings.Data.Services;
using Flash_listings.Data.Interfaces;

namespace Flash_listings.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductsService _productService;
        public ProductsController(
            IProductsService productService)
        {
           
            _productService = productService;
        }

        // GET api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAsync(string language = "en")
        {
            var products = await _productService.GetAllProductsAsync(language);
            return Ok(products);
        }

        // GET: Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAsync(int id, string language = "en")
        {
            var product = await _productService.GetProductByIdAsync(id, language);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        // PUT: Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, CreateProductDTO product , string lang="en")
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, product ,lang);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        // POST: Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductDTO product , string lang ="en")
        {
            var createdProduct = await _productService.CreateProductAsync(product ,lang);
            return Ok(createdProduct);

        }

        // DELETE: Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedProduct = await _productService.DeleteProductAsync(id);
            if (deletedProduct == false)
            {
                return NotFound();
            }

            return Ok(deletedProduct);
        }

        
    }
}
