using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;
using MyTests.Pages;

namespace MyTests.Steps
{
    [Binding]
    public class CartSteps
    {
        private readonly CartPage _cart;

        public CartSteps(CartPage cart)
        {
            _cart = cart;
        }

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
            await Expect(_cart.InventoryItem()).ToHaveCountAsync(0);
        }

        [Then(@"The cart should have (.*) items")]
        public async Task ThenTheCartShouldHaveItems(int itemCount)
        {
            await Expect(_cart.InventoryItem()).ToHaveCountAsync(itemCount);
        }

        [Then(@"The product in cart should be ""(.*)""")]
        public async Task ThenTheProductInCartShouldBe(string expectedName)
        {
            var actualName = (await _cart.ItemName().InnerTextAsync()).Trim();
            Assert.That(actualName, Is.EqualTo(expectedName));
        }
    }
}
