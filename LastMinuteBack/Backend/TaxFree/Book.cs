using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Book : TaxFreeProduct
    {
        public Book(bool imported) : base(imported)
        {
        }

        public static new Book TryParse(string prodLiteral)
        {
            if (prodLiteral.ToUpper().Contains("BOOK"))
            {
                return new Book(prodLiteral.ToUpper().Contains("IMPORTED"));
            }
            return null;
        }
    }
}
