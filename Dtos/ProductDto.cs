using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000RestAPI.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int CountInStock { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
