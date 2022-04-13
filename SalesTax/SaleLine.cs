using System;

namespace SalesTax
{
    public class SaleLine
    {
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public bool IsImported { get; private set; }
        public int Quantity { get; private set; }
        public decimal LineValue { get; private set; }
        public decimal Tax { get; private set; }

        /// <summary>
        /// Public constructor for the sale line
        /// </summary>
        /// <param name="lineQuantity">Quantity on order</param>
        /// <param name="name">name of the product</param>
        /// <param name="unitPrice">price of a single item</param>
        /// <param name="itemIsImported">flag to indicate if the item is imported</param>
        public SaleLine(int lineQuantity, string name, decimal unitPrice, bool itemIsImported, TaxFreeProductRegistry registry = null)
        {
            int taxRate;
            if (string.IsNullOrEmpty(name)) name = string.Empty;

            Quantity = lineQuantity;
            ProductName = name;
            Price = unitPrice;
            IsImported = itemIsImported;
            LineValue = Price * Quantity;

            if (ProductName.Contains("book") || ProductName.Contains("tablet") || ProductName.Contains("tomatoes"))
                taxRate = 0;  //No sales tax for books, medicals items or food
            else
                taxRate = 10; //10% sales tax or general products
            if (IsImported)
                taxRate = 5; //5% import tax

            var taxAmount = CalculateTax(LineValue,taxRate);
            LineValue += taxAmount;
        }

        /// <summary>
        /// Calculates the amount of tax for a value, rounded up to the nearest 5 cents
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="taxRate">The tax rate to apply</param>
        /// <returns>The calculated tax on the original value</returns>
        public static decimal CalculateTax(decimal value, int taxRate)
        {
            double amount;
            double remainder;

            amount = (double)Math.Round((value * taxRate)/100,2);

            //Now round up to nearest 5 cents.
            remainder = amount % .05;
            if (remainder > 0)
                amount += .05 - remainder;
            return (decimal)amount;
        }

        /// <summary>
        /// Converts the sale line to a string
        /// </summary>
        /// <returns>The string representation of the sale line</returns>
        public override string ToString()
        {
            return string.Format($"{Quantity} {ProductName}: {LineValue:#,###.00}");
        }
    }
}
