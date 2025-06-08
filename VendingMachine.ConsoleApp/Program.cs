using System.Collections.Generic;
using VendingMachine.Core;
using VendingMachine.Infrastructure;

namespace VendingMachine.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var validator = new CoinValidator();
            var display = new ConsoleDisplay();
            var dispenser = new ProductDispenser();

            var machine = new VendingMachineApp(validator, display, dispenser);
            machine.AcceptCoin("quarter");
            machine.SelectProduct("cola");
        }
    }

    public class VendingMachineApp
    {
        private readonly ICoinValidator _coinValidator;
        private readonly IDisplay _display;
        private readonly IProductDispenser _dispenser;
        private decimal _currentAmount = 0;
        private readonly Dictionary<string, Product> _products;

        public VendingMachineApp(ICoinValidator coinValidator, IDisplay display, IProductDispenser dispenser)
        {
            _coinValidator = coinValidator;
            _display = display;
            _dispenser = dispenser;
            _products = new()
            {
                { "cola", new Product("Cola", 1.00m) },
                { "chips", new Product("Chips", 0.50m) },
                { "candy", new Product("Candy", 0.65m) }
            };
        }

        public void AcceptCoin(string coin)
        {
            var coinType = _coinValidator.Validate(coin);
            if (coinType == CoinType.Invalid)
            {
                _display.ShowMessage("Coin Rejected");
                return;
            }
            _currentAmount += CoinValues.Values[coinType];
            _display.ShowMessage($"Current Amount: ${_currentAmount:F2}");
        }

        public void SelectProduct(string productKey)
        {
            if (!_products.ContainsKey(productKey))
            {
                _display.ShowMessage("Invalid Selection");
                return;
            }

            var product = _products[productKey];
            if (_currentAmount >= product.Price)
            {
                _dispenser.Dispense(product);
                _display.ShowMessage("THANK YOU");
                _currentAmount = 0;
            }
            else
            {
                _display.ShowMessage($"PRICE: ${product.Price:F2}");
            }
        }
    }
}
