using Flash_listings.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flash_listings.Data.Interfaces
{
    public interface ICategoriessService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(string lang);
        public Task<CategoryDTO> GetCategoryByIdAsync(int categoryId, string lang);
        public Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
