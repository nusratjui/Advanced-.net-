using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Vone.Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }
}