using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ProductParser
    {
        public static Product ParseLine(string prodCandidate)
        {
            if (string.IsNullOrEmpty(prodCandidate) ||
                !prodCandidate.Contains(" at "))
            {
                return null;
            }

            string[] piezes = prodCandidate.Split(' ');
            if (piezes.Count() < 4)
            {
                return null;
            }

            int amount;
            if (!int.TryParse(piezes[0], out amount))
            {
                return null;
            }

            Book book = Book.TryParse(prodCandidate);
            if (book != null)
            {
                return book;
            }

            Food food = Food.TryParse(prodCandidate);
            if (food != null)
            {
                return food;
            }

            Medical medical= Medical.TryParse(prodCandidate);
            if (medical != null)
            {
                return medical;
            }

            Product prod = Product.TryParse(prodCandidate);
            if (prod != null)
            {
                return prod;
            }
            return null;
        }
    }
}
