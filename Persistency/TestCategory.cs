using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rema1000RestAPI.Models;

namespace Rema1000RestAPI.Persistency
{
    public class TestCategory
    {
        public static void Seed(DBContext databaseContext)
        {
            if (!databaseContext.Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Dipers",
                        Description = "A Very good product"

                    },
                    new Category
                    {
                        Name = "Grape Soda",
                        Description = "A Delicious grape soda"
                    },
                    new Category
                    {
                        Name = "Lemon Soda",
                        Description = "A Delicious lemon soda"
                    }
                };
                databaseContext.Categories.AddRange(categories);
                databaseContext.SaveChanges();
            }
        }
    }
}
