# 🧪 Playwright SpecFlow C# Automation Framework

This is an end-to-end UI automation framework built with **.NET (C#)**, **Playwright**, and **SpecFlow (BDD)**.  
It was converted from a TypeScript Playwright setup into a clean C#-based test framework for maintainability, scalability, and CI/CD integration.

---

## 🚀 Tech Stack

| Component | Description |
|------------|--------------|
| **.NET 9** | Target framework |
| **C#** | Core programming language |
| **Playwright for .NET** | Browser automation and UI testing |
| **SpecFlow** | BDD framework (Cucumber for .NET) |
| **NUnit** | Test runner integration |
| **BoDi** | Dependency Injection container for SpecFlow |
| **Microsoft.Playwright.NUnit** | Integration layer for Playwright + NUnit |
| **TestExecution.json** | Test results output for LivingDoc reports |


---

## 🧩 Prerequisites

Make sure you have the following installed:

- **.NET SDK 9.0+** → [Download .NET](https://dotnet.microsoft.com/download)
- **Playwright Browsers**
  ```bash
  cd tests
  pwsh bin/Debug/net9.0/playwright.ps1 install

1️⃣ Restore dependencies
dotnet restore

2️⃣ Build the solution
dotnet build

3️⃣ Run tests

From the tests folder:
dotnet test -c Debug -f net9.0

Generate Test Report (SpecFlow LivingDoc)

You can create a rich, interactive HTML report for all executed SpecFlow scenarios using SpecFlow LivingDoc.

🔧 Prerequisites

Ensure the global LivingDoc CLI is installed:
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

Generate the HTML report:
livingdoc test-assembly bin/Debug/net9.0/tests.dll --output LivingDoc.html --test-execution-json bin/Debug/net9.0/TestExecution.json

Open reoprt: 
open LivingDoc.html