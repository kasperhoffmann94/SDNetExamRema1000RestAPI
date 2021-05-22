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

namespace Rema1000RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly DBContext _context;

        public SupplierController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Create(SupplierDto supplierDto)
        {
            Supplier newSupplier = new Supplier
            {
                Name = supplierDto.Name,
                Adress = supplierDto.Adress,
                ContactPerson = supplierDto.ContactPerson,
                Zip = supplierDto.Zip,
                Email = supplierDto.Email,
                PhoneNumber = supplierDto.PhoneNumber

            };
            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> Get(int? id)
        {
            List<Supplier> suppliers = new List<Supplier>();

            if (id.HasValue)
            {
                Supplier specificSupplier = await _context.Suppliers.FirstAsync(supplier => supplier.ID == id);
                suppliers.Add(specificSupplier);
                return suppliers;
            }
            suppliers = await _context.Suppliers.ToListAsync();
            _context.SaveChanges();
            return suppliers;

        }


        [HttpPut]
        public async void Update(int supplierID, SupplierDto supplierDto)
        {
            Supplier specificSupplier = await _context.Suppliers.FirstAsync(supplier => supplier.ID == supplierID);
            specificSupplier.Adress = supplierDto.Adress;
            specificSupplier.Name = supplierDto.Name;
            specificSupplier.ContactPerson = supplierDto.ContactPerson;
            specificSupplier.Email = supplierDto.Email;
            specificSupplier.PhoneNumber = supplierDto.PhoneNumber;
            specificSupplier.Zip = supplierDto.Zip;
            _context.Suppliers.Update(specificSupplier);
            _context.SaveChanges();
        }

        [HttpDelete]
        public async void Delete(int supplierId)
        {
            Supplier specificSupplier = await _context.Suppliers.FirstAsync(supplier => supplier.ID == supplierId);
            _context.Suppliers.Remove(specificSupplier);
            _context.SaveChanges();
        }
    }
}
