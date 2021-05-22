using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000RestAPI.Models;

namespace Rema1000RestAPI.Persistency
{
    public class TestSupplier
    {
        public static void Seed(DBContext databaseContext)
        {
            if (!databaseContext.Suppliers.Any())
            {
                List<Supplier> suppliers = new List<Supplier>
                {
                    new Supplier
                    {
                        Name = "Fast supplier",
                        Adress = "Bogensvej 105",
                        ContactPerson = "Andreas",
                        Email = "asdasd@aSD.dk",
                        PhoneNumber = "12345678",
                        Zip = "5270",



                    },
                    new Supplier
                    {
                        Name = "Slow supplier",
                        Adress = "Slow road 23",
                        ContactPerson = "Morten",
                        Email = "morten@ecl.dk",
                        PhoneNumber = "22334455",
                        Zip = "2000",

                    },
                    new Supplier
                    {
                        Name = "Postnord",
                        Adress = "Taulov",
                        ContactPerson = "Henning",
                        Email = "Hen@hen.dk",
                        PhoneNumber = "11223344",
                        Zip = "6200",

                    }
                };
                databaseContext.Suppliers.AddRange(suppliers);
                databaseContext.SaveChanges();
            }
        }
    }
}
