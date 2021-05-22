using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rema1000RestAPI.Dtos;
using Rema1000RestAPI.Models;
using Rema1000RestAPI.Persistency;
using Rema1000RestAPI.Services;

namespace Rema1000RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly ValidationService _validationService;

        public ProductController(DBContext context)
        {
            _context = context;
            _validationService = new ValidationService(_context);
        }

        [HttpPost]
        public async void Create(ProductDto productDto)
        {
            try
            {
                _validationService.CheckForCategory(productDto.CategoryId);
                _validationService.CheckForSupplier(productDto.SupplierId);

                Product newProduct = new Product
                {
                    Name = productDto.Name,
                    Category = await _context.Categories.FindAsync(productDto.CategoryId),
                    Supplier = await _context.Suppliers.FindAsync(productDto.SupplierId),
                    Count = productDto.Count,
                    CountInStock = productDto.CountInStock,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    Unit = productDto.Unit
                };
                _context.Products.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            catch (NotFoundExeption ex)
            {
                Console.WriteLine(ex.Message, ex);
            }


        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get(int? id)
        {
            List<Product> products = new List<Product>();

            if (id.HasValue)
            {
                Product specificProduct = await _context.Products.Include(product => product.Category).Include(product => product.Supplier).FirstAsync(product => product.ID == id);
                products.Add(specificProduct);
                return products;
            }
            products = await _context.Products.Include(product => product.Category).Include(product => product.Supplier).ToListAsync();


            _context.SaveChanges();
            return products;

        }


        [HttpPut]
        public async void Update(int productId, ProductDto productDto)
        {
            try
            {
                _validationService.CheckForCategory(productDto.CategoryId);
                _validationService.CheckForSupplier(productDto.SupplierId);

                Product specificProduct = await _context.Products.FirstAsync(product => product.ID == productId);
                specificProduct.Name = productDto.Name;
                specificProduct.Category = await _context.Categories.FindAsync(productDto.CategoryId);
                specificProduct.Supplier = await _context.Suppliers.FindAsync(productDto.SupplierId);
                specificProduct.Count = productDto.Count;
                specificProduct.CountInStock = productDto.CountInStock;
                specificProduct.Description = productDto.Description;
                specificProduct.Price = productDto.Price;
                specificProduct.Unit = productDto.Unit;


                _context.Products.Update(specificProduct);
                await _context.SaveChangesAsync();
            }
            catch (NotFoundExeption ex)
            {
                Console.WriteLine(ex.Message, ex);
            }


        }

        [HttpDelete]
        public async void Delete(int productId)
        {
            Product specificProduct = await _context.Products.FirstAsync(product => product.ID == productId);
            _context.Products.Remove(specificProduct);
            _context.SaveChanges();
        }


    }
}
