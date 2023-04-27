using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flash_listings.Data;
using Flash_listings.Models;
using Flash_listings.Data.Interfaces;

namespace Flash_listings.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private readonly ICategoriessService _categoryService;

        public CategoriesController(ICategoriessService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(string lang ="en")
        {
            var cat = await _categoryService.GetAllCategoriesAsync(lang);
            return Ok(cat);
        }

        // GET: Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id , string lang ="en")
        {
            var category = await _categoryService.GetCategoryByIdAsync(id , lang);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        // DELETE: Categories
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.DeleteCategoryAsync(id);
            if (category == false)
            {
                return NotFound();
            }


            return Ok(category);
        }

    }
}
