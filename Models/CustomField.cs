using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Models
{
    public class CustomField
    {
        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<CustomFieldKeyValue> KeyValues { get; set; }

    }

    public class CustomFieldKeyValue
    {
        public int Id { get; set; }
        public string KeyEn { get; set; }
        public string KeyAr { get; set; }
        public string ValueEn { get; set; }
        public string ValueAr { get; set; }
        public int CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
    }
}
