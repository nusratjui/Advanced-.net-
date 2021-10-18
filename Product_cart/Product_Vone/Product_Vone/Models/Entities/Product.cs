using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Product_Vone.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert the name")]
        [StringLength(10, ErrorMessage = "Maximum 10 digit allowed")]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Des { get; set; }

    }
}