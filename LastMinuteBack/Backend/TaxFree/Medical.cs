using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Medical : TaxFreeProduct
    {
        public Medical(bool imported) : base(imported)
        {
        }

        public static new Medical TryParse(string prodLiteral)
        {
            if (prodLiteral.ToUpper().Contains("PILL"))
            {
                return new Medical(prodLiteral.ToUpper().Contains("IMPORTED"));
            }
            return null;
        }
    }
}
