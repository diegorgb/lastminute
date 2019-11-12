using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ProductParser
    {
        public static List<Product> ParseLine(string prodCandidate)
        {
            List<Product> result = new List<Product>();

            if (string.IsNullOrEmpty(prodCandidate) ||
                !prodCandidate.Contains(" at "))
            {
                return result;
            }

            string[] piezes = prodCandidate.Split(' ');
            if (piezes.Count() < 4)
            {
                return result;
            }
            double price;
            if (!double.TryParse(piezes[piezes.Length - 1].Replace('.', ','), out price))
            {
                return result;
            }

            int amount;
            if (!int.TryParse(piezes[0], out amount))
            {
                return result;
            }

            Product prod = Book.TryParse(prodCandidate);
            if (prod != null)
            {
                for (int i=0; i<amount; i++)
                {
                    Product p = new Book(prod.Imported)
                    {
                        Price = price
                    };
                    result.Add(p);
                }
                return result;
            }

            prod = Food.TryParse(prodCandidate);
            if (prod != null)
            {
                for (int i = 0; i < amount; i++)
                {
                    Product p = new Food(prod.Imported)
                    {
                        Price = price
                    };
                    result.Add(p);
                }
                return result;
            }

            prod = Medical.TryParse(prodCandidate);
            if (prod != null)
            {
                for (int i = 0; i < amount; i++)
                {
                    Product p = new Medical(prod.Imported)
                    {
                        Price = price
                    };
                    result.Add(p);
                }
                return result;
            }

            prod = Product.TryParse(prodCandidate);
            if (prod != null)
            {
                for (int i = 0; i < amount; i++)
                {
                    Product p = new Product(prod.Imported)
                    {
                        Price = price
                    };
                    result.Add(p);
                }
                return result;
            }

            return result;
        }
    }
}
