using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp;

namespace ShopApp
{
    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }

        public Product(string name ,string price, string image)
		{
            Name = name;
            Price = price;
            Image = image;
		}
    }
}
