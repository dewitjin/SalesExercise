using Xunit;

namespace SalesTax.Tests
{
    public class MethodSignatureTests
    {
        /*
            Please don't change this file, changing this file will cause your changes to be rejected
        */
        [Fact]
        public void Input_parser_method_signature_is_unchanged()
        {
            //Will submitted code be callable by the unit tests we don't show you?
            var processInput = typeof(InputParser).GetMethod("ProcessInput");
            var arguments = processInput.GetParameters();
            Assert.Equal(2, arguments.Length);
            Assert.True(arguments[1].IsOptional && arguments[1].HasDefaultValue && arguments[1].ParameterType.Equals(typeof(TaxFreeProductRegistry)), "The registry parameter must be present and optional");

            var calcTax = typeof(SaleLine).GetMethod("CalculateTax");
            Assert.True(calcTax.IsStatic && calcTax.IsPublic, "CalculateTax needs to be a public static method");

            var saleLineCtor = typeof(SaleLine).GetConstructor(new [] { typeof(int), typeof(string), typeof(decimal), typeof(bool), typeof(TaxFreeProductRegistry) });
            Assert.NotNull(saleLineCtor);
            arguments = saleLineCtor.GetParameters();
            Assert.Equal(5, arguments.Length);
            Assert.True(arguments[4].IsOptional && arguments[4].HasDefaultValue,"The registry parameter must be optional");
        }
    }
}
