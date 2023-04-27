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
    public class CategoriesService : ICategoriessService
    {
        private readonly FlashListingsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsService> _logger;

        public CategoriesService(
        FlashListingsDbContext dbContext,
        IMapper mapper,
        ILogger<ProductsService> logger
       )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var cat = _dbContext.Categories
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == categoryId);
            if (cat == null)
            {
                return false;
            }

            _dbContext.Categories.Remove(cat);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(string lang="en")
        {
            var categories = _dbContext.Categories
               .Select(p => new CategoryDTO
               {
                   Id = p.Id,
                   Name = lang == "en" ? p.NameEn : p.NameAr,
                   Products = p.Products.Select(pr => new ProductDTO
                   {
                       Id = pr.Id,
                       CreationDate = pr.CreationDate,
                       Duration = pr.Duration,
                       Name = lang == "en" ? pr.NameEn : pr.NameAr,
                       Price = pr.Price,
                       StartDate = pr.StartDate,
                       CustomFields = pr.CustomFields.Select(cf => new CustomFieldDTO
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
                   }).ToList()
               }).ToList();



            var catDtos = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return catDtos;

        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int categoryId, string lang)
        {
            var categories = _dbContext.Categories
               .Select(p => new CategoryDTO
               {
                   Id = p.Id,
                   Name = lang == "en" ? p.NameEn : p.NameAr,
                   Products = p.Products.Select(pr => new ProductDTO
                   {
                       Id = pr.Id,
                       CreationDate = pr.CreationDate,
                       Duration = pr.Duration,
                       Name = lang == "en" ? pr.NameEn : pr.NameAr,
                       Price = pr.Price,
                       StartDate = pr.StartDate,
                       CustomFields = pr.CustomFields.Select(cf => new CustomFieldDTO
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
                   }).ToList()
               }).FirstOrDefault(x => x.Id == categoryId);



            var catDtos = _mapper.Map<CategoryDTO>(categories);

            return catDtos;
        }
    }
   
}
