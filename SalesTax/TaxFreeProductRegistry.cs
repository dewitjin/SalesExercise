using System;
using System.Collections.Generic;

namespace SalesTax
{
    public class TaxFreeProductRegistry
    {
        private readonly List<string> productNames = new List<string>() {};

        //Should a product be sales tax free?
        public bool Includes(string name)
        {
            throw new NotImplementedException();
        }

        //Add a product to the tax free registry
        public void Add(string itemName)
        {
            productNames.Add(itemName);
        }

        //The number of products in the registry
        public int Length { get { return productNames.Count; } }
    }
}
