using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Rema1000RestAPI.Persistency
{
    public class TestData
    {
        public static void Seed(DBContext databaseContext)
        {
            //TestProduct.Seed(databaseContext);
            TestCategory.Seed(databaseContext);
            TestSupplier.Seed(databaseContext);
        }
    }
}
