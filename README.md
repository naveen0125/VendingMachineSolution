# 🥤 VendingMachineSolution

A modular and testable simulation of a vending machine built using **SOLID principles** in **C# with .NET 6**. This solution separates concerns clearly and promotes maintainability, extensibility, and testability through a layered architecture.

---

## 🔧 Features

- Accepts valid coins: `nickel`, `dime`, `quarter`
- Rejects invalid coins with proper messaging
- Displays running total and user instructions (`INSERT COIN`, `THANK YOU`, etc.)
- Handles product selection for: `Cola ($1.00)`, `Chips ($0.50)`, `Candy ($0.65)`
- Implements key **SOLID design principles**
- Includes unit tests with **NUnit** and **Moq**

---

## 📂 Project Structure

```
VendingMachineSolution/
├── VendingMachine.Core/           # Domain logic: interfaces, models
├── VendingMachine.Infrastructure/ # Concrete service implementations
├── VendingMachine.ConsoleApp/     # CLI simulation interface
├── VendingMachine.Tests/          # NUnit-based unit tests
└── VendingMachineSolution.sln     # Solution file
```

---

## 🚀 Getting Started

### ✅ Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- IDE like Visual Studio, Rider, or Visual Studio Code

### ⚙️ Build & Run

```bash
dotnet restore
dotnet build
dotnet run --project VendingMachine.ConsoleApp
```

### 🧪 Run Tests

```bash
dotnet test
```

---

## 🧠 SOLID Principles Applied

- **Single Responsibility** – each class has a single job (e.g., CoinValidator only validates coins)
- **Open/Closed** – system can grow with new coins/products without rewriting logic
- **Liskov Substitution** – interface implementations behave predictably
- **Interface Segregation** – only necessary methods are exposed per interface
- **Dependency Inversion** – high-level modules depend on abstractions

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---
