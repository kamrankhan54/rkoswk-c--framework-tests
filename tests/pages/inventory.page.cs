// InventoryPage.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using MyTests.Support;
using System.Globalization;
using System.Linq;
using NUnit.Framework;


namespace MyTests.Pages;

public sealed class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    // LOCATORS
    public ILocator InventoryList => _page.Locator("[data-test=\"inventory-list\"]");
    public ILocator InventoryItem => _page.Locator("[data-test=\"inventory-item\"]");
    public ILocator InventoryItemTitle => _page.Locator("[data-test=\"inventory-item-name\"]");
    public ILocator InventoryItemDescription => _page.Locator("[data-test=\"inventory-item-desc\"]");
    public ILocator InventoryItemPrice => _page.Locator("[data-test=\"inventory-item-price\"]");
    public ILocator ProductSortDropdown => _page.Locator("[data-test=\"product-sort-container\"]");

    public ILocator InventoryItemImage(string productName) =>
        _page.Locator($"[data-test=\"inventory-item-{productName}-img\"]");

    public ILocator InventoryItemAddToBasket(string productName) =>
        _page.Locator($"[data-test=\"add-to-cart-{productName}\"]");

    public ILocator RemoveProduct(string name) =>
        _page.Locator($"[data-test=\"remove-{name}\"]");

    // ACTIONS
    public async Task AddItemToBasketAsync(string name)
    {
        var slug = Utils.ProductSlug(name); // your productSlug equivalent
        var addButton = InventoryItemAddToBasket(slug);
        await Expect(addButton).ToBeVisibleAsync();
        await addButton.ClickAsync();
    }

    public async Task RemoveItemAsync(string name)
    {
        var slug = Utils.ProductSlug(name);
        var removeButton = RemoveProduct(slug);
        await Expect(removeButton).ToBeVisibleAsync();
        await removeButton.ClickAsync();
    }

    public async Task SortByAsync(string optionLabel)
    {
        await ProductSortDropdown.SelectOptionAsync(new SelectOptionValue { Label = optionLabel });
    }

    // VALIDATION
    // using System.Globalization;
    // using System.Linq;
    // using NUnit.Framework;

    public async Task OrderedProductsAsync(string order)
    {
        var sortDropdown = _page.Locator(".product_sort_container");

        // Normalize input
        order = order.ToLowerInvariant();

        // Map user-friendly text from feature files to the dropdown’s actual values
        string sortValue = order switch
        {
            "az" or "name (a to z)" => "az",
            "za" or "name (z to a)" => "za",
            "low to high" or "price (low to high)" => "lohi",
            "high to low" or "price (high to low)" => "hilo",
            _ => throw new ArgumentException($"Unknown sort option: {order}")
        };

        Console.WriteLine($"Sorting by: {order}");

        await sortDropdown.SelectOptionAsync(new[] { sortValue });

        // Optionally, wait for sorting to take effect before continuing
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

}
