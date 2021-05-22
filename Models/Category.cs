using System;
using System.ComponentModel.DataAnnotations;

namespace Rema1000RestAPI.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
