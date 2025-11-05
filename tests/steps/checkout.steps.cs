using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using MyTests.Pages;

namespace MyTests.Steps;

[Binding]
public sealed class CheckoutSteps
{
    private readonly CheckoutPages _checkout;

    public CheckoutSteps(CheckoutPages checkout)
    {
        _checkout = checkout;
    }

    // Your feature sometimes starts this step with Given, sometimes with When
    [Given(@"Complete my information using first name ""(.*)"" last name ""(.*)"" postcode ""(.*)""")]
    [When(@"Complete my information using first name ""(.*)"" last name ""(.*)"" postcode ""(.*)""")]
    public async Task CompleteMyInfo(string firstName, string lastName, string postcode)
    {
        await _checkout.CompleteInfoAsync(firstName, lastName, postcode);
        await _checkout.ClickContinueAsync();
    }

    [When(@"I click continue")]
    public async Task WhenIClickContinue()
    {
        await _checkout.ClickContinueAsync();
    }

   [When(@"I click finish")]
public async Task WhenIClickFinish()
{
    await _checkout.ClickFinishAsync();
}

    [Then(@"The checkout overview page is displayed for ""(.*)"" product")]
    public async Task ThenCheckoutOverviewDisplayedForProduct(string _productNameFromStep)
    {
        // mimic TS: use data.products[0]
        var data = TestDataLoader.Load();
        var expected = data.Products[0];

        var actualTitle = (await _checkout.ProductTitle.InnerTextAsync()).Trim();
        var actualTotal = (await _checkout.Total.InnerTextAsync()).Trim();

        Assert.That(actualTitle, Is.EqualTo(expected.Title));
        Assert.That(actualTotal, Is.EqualTo(expected.Total));
    }

    [Then(@"The thank for your order page is displayed")]
    public async Task ThenThankForYourOrderDisplayed()
    {
        var msg = (await _checkout.ThankYouMessage.InnerTextAsync()).Trim();
        Assert.That(msg, Is.EqualTo("Thank you for your order!"));
    }
}

// Simple JSON loader (data/data.json) — keep once in your project.
file static class TestDataLoader
{
    private static DataRoot? _cached;

    public static DataRoot Load()
    {
        if (_cached is not null) return _cached;

        var path = Path.Combine(AppContext.BaseDirectory, "data", "data.json");
        var json = File.ReadAllText(path);
        _cached = JsonSerializer.Deserialize<DataRoot>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new DataRoot();

        return _cached;
    }
}

public sealed class DataRoot
{
    public List<ProductData> Products { get; set; } = new();
}

public sealed class ProductData
{
    public string Title { get; set; } = "";
    public string Total { get; set; } = "";
}
