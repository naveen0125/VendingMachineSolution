using NUnit.Framework;
using Moq;
using VendingMachine.Core;
using VendingMachine.Infrastructure;
using VendingMachine.ConsoleApp;

namespace VendingMachine.Tests
{
    public class Tests
    {
        private VendingMachineApp _vm;
        private Mock<IDisplay> _display;
        private Mock<IProductDispenser> _dispenser;
        private ICoinValidator _coinValidator;

        [SetUp]
        public void Setup()
        {
            _coinValidator = new CoinValidator();
            _display = new Mock<IDisplay>();
            _dispenser = new Mock<IProductDispenser>();
            _vm = new VendingMachineApp(_coinValidator, _display.Object, _dispenser.Object);
        }

        [Test]
        public void AcceptCoin_ValidCoin_ShouldIncreaseAmount()
        {
            _vm.AcceptCoin("quarter");
            _display.Verify(d => d.ShowMessage("Current Amount: $0.25"));
        }

        [Test]
        public void AcceptCoin_InvalidCoin_ShouldShowRejected()
        {
            _vm.AcceptCoin("penny");
            _display.Verify(d => d.ShowMessage("Coin Rejected"));
        }
    }
}
