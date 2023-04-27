using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
