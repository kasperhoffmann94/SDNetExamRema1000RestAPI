using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000RestAPI.Dtos
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
