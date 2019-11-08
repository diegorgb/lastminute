using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Food : TaxFreeProduct
    {
        public Food(bool imported) : base(imported)
        {
        }

        public static new Food TryParse(string prodLiteral)
        {
            if (prodLiteral.ToUpper().Contains("CHOCOLATE"))
            {
                return new Food(prodLiteral.ToUpper().Contains("IMPORTED"));
            }
            return null;
        }
    }
}
