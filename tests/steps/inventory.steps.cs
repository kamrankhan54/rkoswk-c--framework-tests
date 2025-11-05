using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using MyTests.Pages;
using static Microsoft.Playwright.Assertions;

namespace MyTests.Steps;

[Binding]
public sealed class InventorySteps
{
    private readonly InventoryPage _inventory;

    public InventorySteps(InventoryPage inventory)
    {
        _inventory = inventory;
    }

    [Given(@"I add ""(.*)"" product to cart")]
    public async Task GivenIAddProductToCart(string name)
    {
        await _inventory.AddItemToBasketAsync(name);
    }

    [When(@"I sort products by ""(.*)""")]
    public async Task WhenISortProductsBy(string order)
    {
        await _inventory.SortByAsync(order);
    }

    [Then(@"Products should be ordered by ""(.*)""")]
    public async Task ThenProductsShouldBeOrderedBy(string order)
    {
        await _inventory.OrderedProductsAsync(order);
    }

    [Then(@"The inventory should have all items displayed")]
    public async Task ThenInventoryShouldHaveAllItemsDisplayed()
    {
        await Expect(_inventory.InventoryItem).ToHaveCountAsync(6);
    }

    [Then(@"Product ""(.*)"" image should not have the placeholder image")]
    public async Task ThenProductImageShouldNotHavePlaceholder(string name)
    {
        var image = _inventory.InventoryItemImage(name);
        var src = await image.GetAttributeAsync("src");
        Assert.That(src, Does.Not.Contain("/static/media/sl-404.168b1cce.jpg"));
    }
}
