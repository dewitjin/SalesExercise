using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
    public class Sale
    {
        private List<SaleLine> saleLines = new List<SaleLine>();
        public decimal Tax { get; private set; }
        public decimal TotalValue { get; private set; }
        public TaxFreeProductRegistry Registry { get; private set; }

        public Sale(TaxFreeProductRegistry registry = null)
        {
            Registry = registry;
        }

        /// <summary>
        /// Adds a line to the sale.
        /// </summary>
        /// <param name="inputLine">The line to add.</param>
        /// <returns>True for success, False for failure.  Failures are usually caused via incorrect formatting of the input</returns>
        public bool Add(string inputLine)
        {
            SaleLine saleLine;
            try
            {
                saleLine = InputParser.ProcessInput(inputLine);
                saleLines.Add(saleLine);
                Tax += saleLine.Tax;
                TotalValue += saleLine.LineValue;
                return true;
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }

            return false;
        }

        /// <summary>
        /// Converts the sale to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (SaleLine line in saleLines)
            {
                if (output.Length > 0)
                    output.Append("\n");
                output.Append(line.ToString());
            }
            //Now add footer information
            output.Append("\n");
            output.AppendFormat($"Sales Taxes: {Tax:#,##0.00}");
            output.Append("\n");
            output.AppendFormat($"Total: {TotalValue:#,##0.00}");
            return output.ToString();
        }
    }
}
