using VendingMachine.Core;
using System;

namespace VendingMachine.Infrastructure
{
    public class CoinValidator : ICoinValidator
    {
        public CoinType Validate(string coin) =>
            coin switch
            {
                "nickel" => CoinType.Nickel,
                "dime" => CoinType.Dime,
                "quarter" => CoinType.Quarter,
                _ => CoinType.Invalid
            };
    }

    public class ConsoleDisplay : IDisplay
    {
        public void ShowMessage(string message) => Console.WriteLine(message);
    }

    public class ProductDispenser : IProductDispenser
    {
        public void Dispense(Product product) =>
            Console.WriteLine($"Dispensing {product.Name}");
    }
}
