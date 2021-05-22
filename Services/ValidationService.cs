using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000RestAPI.Models;
using Rema1000RestAPI.Persistency;

namespace Rema1000RestAPI.Services
{
    public class ValidationService
    {
        private DBContext _dbContext;

        public ValidationService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void CheckForCategory(int categoryId)
        {
            var result = await _dbContext.Categories.FindAsync(categoryId);

            if (result == null)
            {
                throw new NotFoundExeption(nameof(Category), categoryId);
            }

        }

        public async void CheckForSupplier(int supplierId)
        {
            var result = await _dbContext.Suppliers.FindAsync(supplierId);

            if (result == null)
            {
                throw new NotFoundExeption(nameof(Supplier), supplierId);
            }

        }
    }
}
