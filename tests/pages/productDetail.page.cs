// ProductDetailPage.cs
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace MyTests.Pages;

public sealed class ProductDetailPage
{
    private readonly IPage _page;

    public ProductDetailPage(IPage page)
    {
        _page = page;
    }

    // LOCATORS
    public ILocator AddToBasket => _page.Locator("[data-test=\"add-to-cart\"]");

    // ACTIONS
    public async Task AddItemToBasketAsync()
    {
        await AddToBasket.ClickAsync();
    }

    public async Task ViewProductPageAsync(string name)
    {
        var item = _page.Locator("[data-test=\"inventory-item-name\"]", new PageLocatorOptions { HasTextString = name });
        await item.ClickAsync();
    }
}
