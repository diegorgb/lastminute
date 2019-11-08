﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public bool TaxFree { get; protected set; }
        public bool Imported { get; protected set; }

        public const int BasicTax = 10;
        public const int ImportTax = 5;

        public Product(bool imported)
        {
            Imported = imported;
        }

        public double CalculateTaxes()
        {
            double totalTax = TaxFree ? 0 : Price * BasicTax / 100;
            if (Imported)
            {
                totalTax += Price * ImportTax / 100;
            }

            return Math.Round(totalTax, 2, MidpointRounding.AwayFromZero);
        }

        public static Product TryParse(string prodLiteral)
        {
            return new Product(prodLiteral.ToUpper().Contains("IMPORTED"));
        }
    }
}
