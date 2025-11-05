using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using MyTests.Pages;
using static Microsoft.Playwright.Assertions;

namespace MyTests.Steps;

[Binding]
public sealed class CartSteps
{
    private readonly CartPage _cart;

    public CartSteps(CartPage cart)
    {
        _cart = cart;
    }

    // Map both Given & When as your features use both
    [Given(@"I open the cart page")]
    [When(@"I open the cart page")]
    public async Task OpenCartPageAsync()
    {
        await _cart.OpenAsync();
    }

    [When(@"I click checkout")]
    public async Task WhenIClickCheckout()
    {
        await _cart.ClickCheckoutAsync();
    }

    [Given(@"I remove ""(.*)"" product from cart")]
    public async Task GivenIRemoveProductFromCart(string name)
    {
        await _cart.RemoveItemAsync(name);
    }

    [Then(@"The cart page should be empty")]
    public async Task ThenTheCartPageShouldBeEmpty()
    {
        await Expect(_cart.InventoryItem).ToHaveCountAsync(0);
    }

    [Then(@"The cart should have (.*) items")]
    public async Task ThenTheCartShouldHaveItems(int itemCount)
    {
        await Expect(_cart.InventoryItem).ToHaveCountAsync(itemCount);
    }

    [Then(@"The product in cart should be ""(.*)""")]
    public async Task ThenTheProductInCartShouldBe(string name)
    {
        var productName = (await _cart.ItemName.InnerTextAsync()).Trim();
        Assert.That(productName, Is.EqualTo(name));
    }
}
