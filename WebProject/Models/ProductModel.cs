using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class ProductModel
    {
        [Required]
        public int custId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string custName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}