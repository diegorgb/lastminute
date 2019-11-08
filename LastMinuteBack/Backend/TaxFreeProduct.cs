using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public abstract class TaxFreeProduct : Product
    {
        public TaxFreeProduct(bool imported) : base(imported)
        {
            TaxFree = true;
        }
    }
}
