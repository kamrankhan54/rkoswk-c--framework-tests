// CartPage.cs
using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using MyTests.Support;

namespace MyTests.Pages;

public sealed class CartPage
{
    private readonly IPage _page;
    private readonly string _cartPageUrl;

    public CartPage(IPage page, string cartPageUrl)
    {
        _page = page;
        _cartPageUrl = cartPageUrl;
    }

    // NAVIGATION
    public Task OpenAsync() => _page.GotoAsync(_cartPageUrl);

    // LOCATORS
    public ILocator InventoryItem => _page.Locator("[data-test=\"inventory-item\"]");
    public ILocator ItemName => _page.Locator("[data-test=\"inventory-item-name\"]");
    public ILocator RemoveProduct(string name) => _page.Locator($"[data-test=\"remove-{name}\"]");
    public ILocator CheckoutButton => _page.Locator("[data-test=\"checkout\"]");

    // ACTIONS
    public async Task RemoveItemAsync(string name)
    {
        var slug = Utils.ProductSlug(name); // your productSlug equivalent
        var removeButton = RemoveProduct(slug);
        await Expect(removeButton).ToBeVisibleAsync();
        await removeButton.ClickAsync();
    }

    public async Task ClickCheckoutAsync()
    {
        await Expect(CheckoutButton).ToBeVisibleAsync();
        await CheckoutButton.ClickAsync();
    }
}
