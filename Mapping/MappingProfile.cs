using AutoMapper;
using Flash_listings.Data.ModelDTO;
using Flash_listings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // You are just creating a local mapper config/instance here and then discarding it when it goes out of scope...
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();
                cfg.CreateMap<CreateProductDTO, Product>().ReverseMap();
                cfg.CreateMap<CreateProductDTO, ProductDTO>().ReverseMap();
                cfg.CreateMap<CustomFieldDTO, CustomField>().ReverseMap();
                cfg.CreateMap<CustomFieldKeyValueDTO, CustomFieldKeyValue>().ReverseMap();


            });

            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<CustomFieldDTO, CustomField>().ReverseMap();
            CreateMap<CustomFieldKeyValueDTO, CustomFieldKeyValue>().ReverseMap();
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<CreateProductDTO, ProductDTO>().ReverseMap();

        }
    }
}
