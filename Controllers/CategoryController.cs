using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Rema1000RestAPI.Dtos;
using Rema1000RestAPI.Models;
using Rema1000RestAPI.Persistency;

namespace Rema1000RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DBContext _context;

        public CategoryController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Create(CategoryDto categoryDto)
        {
            Category newCategory = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get(int? id)
        {
            List<Category> categories = new List<Category>();

            if (id.HasValue)
            {
                Category specificCategory = await _context.Categories.FirstAsync(category => category.ID == id);
                categories.Add(specificCategory);
                return categories;
            }
            categories = await _context.Categories.ToListAsync();
            _context.SaveChanges();
            return categories;

        }


        [HttpPut]
        public async void Update(int categoryID, CategoryDto categoryDto)
        {
            Category specificCategory = await _context.Categories.FirstAsync(category => category.ID == categoryID);
            specificCategory.Description = categoryDto.Description;
            specificCategory.Name = categoryDto.Name;
            _context.Update(specificCategory);
            _context.SaveChanges();
        }

        [HttpDelete]
        public async void Delete(int categoryId)
        {
            Category specificCategory = await _context.Categories.FirstAsync(category => category.ID == categoryId);
            _context.Categories.Remove(specificCategory);
            _context.SaveChanges();
        }
    }
}
