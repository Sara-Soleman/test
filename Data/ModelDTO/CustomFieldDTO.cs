using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Data.ModelDTO
{
    public class CustomFieldDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<CustomFieldKeyValueDTO> KeyValues { get; set; }
    }
}
