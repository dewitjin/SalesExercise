using System;
using Xunit;

namespace SalesTax.Tests
{
    public class ExampleTests
    {
        [Fact]
        public void Produces_a_valid_receipt_for_a_single_line_sale()
        {
            var sale = new Sale();
            sale.Add("1 book at 12.49");
            var expected ="1 book: 12.49\nSales Taxes: 0.00\nTotal: 12.49";
            var actual = sale.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Produces_a_valid_receipt_for_a_multi_line_sale()
        {
            var sale = new Sale();
            sale.Add("10 imported bottles of whiskey at 27.99");
            sale.Add("10 bottles of local whiskey at 18.99");
            sale.Add("10 packets of iodine tablets at 9.75");
            sale.Add("10 boxes of imported potato chips at 11.25");
            var expected = "10 imported bottles of whiskey: 321.90\n10 bottles of local whiskey: 208.90\n10 packets of iodine tablets: 97.50\n10 imported boxes of potato chips: 118.15\nSales Taxes: 66.65\nTotal: 746.45";
            var actual = sale.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Correct_sale_when_new_product_added_to_registry()
        {
            var registry = new TaxFreeProductRegistry();
            registry.Add("tomato");
            var sale = new Sale(registry);
            sale.Add("2 tomatoes at 20");
            var expected = "2 tomatoes: 40.00\nSales Taxes: 0.00\nTotal: 40.00";
            var actual = sale.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
