using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000RestAPI.Models;

namespace Rema1000RestAPI.Persistency
{
    public class TestProduct
    {
        public static void Seed(DBContext databaseContext)
        {
            if (!databaseContext.Products.Any())
            {
                List<Product> products = new List<Product>
                {
                    new Product
                    {
                        Name = "Grape Soda",
                        Description = "A tasty soft drink",
                        Unit = "ML",
                        Count = 1,
                        Price = 12.5,
                        CountInStock = 10
                    },
                    new Product
                    {
                        Name = "Husk piller",
                        Description = "A Nutrious pill",
                        Unit = "gr",
                        Count = 1,
                        Price = 10.0,
                        CountInStock = 20

                    },
                    new Product
                    {
                        Name = "Weight",
                        Description = "A heavy weight",
                        Unit = "kg",
                        Count = 1,
                        Price = 15.0,
                        CountInStock = 5

                    }
                };
                databaseContext.Products.AddRange(products);
                databaseContext.SaveChanges();
            }

        }
    }
}
