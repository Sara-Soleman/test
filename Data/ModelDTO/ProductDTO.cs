using Flash_listings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Data.ModelDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int categoryId { get; set; }
        public ICollection<CustomFieldDTO> CustomFields { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class CreateProductDTO
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(Category))]
        public int categoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
        

    }
}
