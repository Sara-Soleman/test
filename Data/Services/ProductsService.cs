using AutoMapper;
using Flash_listings.Data.Interfaces;
using Flash_listings.Data.ModelDTO;
using Flash_listings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Data.Services
{
    public class ProductsService : IProductsService
    {
        private readonly FlashListingsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsService> _logger;

        public ProductsService(
        FlashListingsDbContext dbContext,
        IMapper mapper,
        ILogger<ProductsService> logger
       )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(string lang ="en")
        {

            var products = _dbContext.Products
               .Select(p => new ProductDTO
               {
                   Id = p.Id,
                   Name = lang == "en" ? p.NameEn : p.NameAr,
                   CreationDate = p.CreationDate,
                   StartDate = p.StartDate,
                   Duration = p.Duration,
                   Price = p.Price,
                   categoryId = p.categoryId,
                   CustomFields = p.CustomFields.Select(cf => new CustomFieldDTO
                   {
                       Id = cf.Id,
                      
                       Title = lang == "en" ? cf.TitleEn : cf.TitleAr,
                       KeyValues = cf.KeyValues.Select(kv => new CustomFieldKeyValueDTO
                       {
                           Id = kv.Id,
                           Key = lang == "en" ? kv.KeyEn : kv.KeyAr,
                           Value = lang == "en" ? kv.ValueEn : kv.ValueAr
                       }
                       ).ToList()
                   }).ToList()
               }).ToList();


            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return productDtos;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId , string lang = "en")
        {
            var products = _dbContext.Products
                .AsNoTracking()
               .Select(p => new ProductDTO
               {
                   Id = p.Id,
                   Name = lang == "en" ? p.NameEn : p.NameAr,
                   CreationDate = p.CreationDate,
                   StartDate = p.StartDate,
                   Duration = p.Duration,
                   Price = p.Price,
                   categoryId = p.categoryId,
                   CustomFields = p.CustomFields.Select(cf => new CustomFieldDTO
                   {
                       Id = cf.Id,
                       Title = lang == "en" ? cf.TitleEn : cf.TitleAr,
                       KeyValues = cf.KeyValues.Select(kv => new CustomFieldKeyValueDTO
                       {
                           Id = kv.Id,
                           Key = lang == "en" ? kv.KeyEn : kv.KeyAr,
                           Value = lang == "en" ? kv.ValueEn : kv.ValueAr
                       }
                       ).ToList()
                   }).ToList()
               }).FirstOrDefault(p => p.Id == productId);

            if (products == null)
            {
                return null;
            }

            var productDto = _mapper.Map<ProductDTO>(products);
            return productDto;
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto ,string lang ="en")
        {
            var product = _mapper.Map<Product>(createProductDto);
            product.CreationDate = DateTime.Now;
            product.StartDate = DateTime.Now.AddMinutes(createProductDto.Duration);
            
            // Get the category by ID
            var category = await _dbContext.Categories.FindAsync(createProductDto.categoryId);

            if (category == null)
            {
                throw new EntryPointNotFoundException($"Category with ID {createProductDto.categoryId} not found.");
            }

            // Set the category to the product
            product.Category = category;

            // Set the custom fields to the product
            var customFields = new List<CustomField>();
            foreach (var customFieldDto in createProductDto.CustomFields)
            {
                var customField = _mapper.Map<CustomField>(customFieldDto);
                customFields.Add(customField);
            }
            product.CustomFields = customFields;

            _dbContext.Products.Add(product);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error creating product.", ex);
            }
            Task<ProductDTO> p =  GetProductByIdAsync(product.Id, lang);
            ProductDTO pD = await p;
            return pD;
        }

        public async Task<ProductDTO> UpdateProductAsync(int productId, CreateProductDTO updateProductDto ,string lang ="en")
        {
            var product =  _dbContext.Products
                .Include(p => p.CustomFields)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == productId);
            _logger.LogInformation(productId+ " " + updateProductDto.Id + "   " + product.Id);
            if (product == null)
            {
                return null;
            }
            _mapper.Map(updateProductDto, product);
            _logger.LogInformation(product.Id + " " + product.NameEn);
            _dbContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error creating product.", ex);
            }
            Task<ProductDTO> productDto = GetProductByIdAsync(productId ,lang);
            ProductDTO dto = await productDto;
            return dto;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            
            var product = _dbContext.Products
                .Include(x => x.CustomFields)
                .FirstOrDefault(p => p.Id == productId);
            foreach (var item in product.CustomFields)
            {

                var t = _dbContext.CustomFieldKeyValue.FirstOrDefault(x => x.CustomFieldId == item.Id);

                _dbContext.CustomFieldKeyValue.Remove(t);
            }

            if (product == null)
            {
                return false;
            }

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
   
}
