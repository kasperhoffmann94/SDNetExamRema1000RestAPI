using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rema1000RestAPI.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int CountInStock { get; set; }
        public Supplier Supplier { get; set; }
    }
}
