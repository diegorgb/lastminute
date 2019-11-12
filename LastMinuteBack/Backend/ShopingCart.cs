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
        public int NumProducts { get { return basket.Count; } }
        public double TotalTaxes { get { return CalculateTaxes(); } }
        public double TotalPrice { get { return CalculateTotalPrice(); } }
        public Product GetProduct(int i)
        {
            return basket[i];
        }

        public ShopingCart()
        {
            basket = new List<Product>();
        }

        public static ShopingCart TryParse(string[] prodCandidates)
        {
            ShopingCart cart = new ShopingCart();
            foreach (string prodCandidate in prodCandidates)
            {
                List<Product> partial = ProductParser.ParseLine(prodCandidate);
                if (partial.Count > 0)
                {
                    cart.AddProducts(partial);
                }
            }
            return cart;
        }


        public void AddProducts(List<Product> newProductList)
        {
            foreach(Product prod in newProductList)
            {
                AddProduct(prod);
            }
        }

        public void AddProduct(Product newProduct)
        {
            basket.Add(newProduct);
        }

        private double CalculateTaxes()
        {
            double totalTax = 0;
            foreach (Product p in basket)
            {
                totalTax += p.CalculateTaxes();
            }
            return Math.Round(totalTax, 2, MidpointRounding.ToEven);
        }

        private double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (Product p in basket)
            {
                totalPrice += p.FinalPrice;
            }
            return Math.Round(totalPrice, 2, MidpointRounding.ToEven);
        }
    }
}
