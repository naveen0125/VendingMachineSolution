namespace VendingMachine.Core;
using System.Collections.Generic;



    public enum CoinType { Nickel, Dime, Quarter, Invalid }

    public static class CoinValues
    {
        public static readonly Dictionary<CoinType, decimal> Values = new()
        {
            { CoinType.Nickel, 0.05m },
            { CoinType.Dime, 0.10m },
            { CoinType.Quarter, 0.25m }
        };
    }

    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public interface ICoinValidator { CoinType Validate(string coin); }
    public interface IDisplay { void ShowMessage(string message); }
    public interface IProductDispenser { void Dispense(Product product); }

