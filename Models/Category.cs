using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
