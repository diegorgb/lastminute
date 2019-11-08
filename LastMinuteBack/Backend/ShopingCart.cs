using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ShopingCart
    {
        private List<Product> basket;

        public ShopingCart()
        {
            basket = new List<Product>();
        }

        public void AddProduct(Product newProduct)
        {
            basket.Add(newProduct);
        }
    }
}
