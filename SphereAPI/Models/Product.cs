using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SphereAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Product_Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Product_Type { get; set; }
        public string Size { get;  set; }
        public string Color { get; set; }
        public int Order_Id { get; set; }
    }
}
