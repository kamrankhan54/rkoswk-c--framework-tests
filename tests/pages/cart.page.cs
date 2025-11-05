using System.Threading.Tasks;
using Microsoft.Playwright;

namespace MyTests.Pages
{
    public static class Utils
    {
        public static string ProductSlug(string name) =>
            name.ToLowerInvariant().Trim().Replace(" ", "-");
    }

    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        public async Task OpenAsync(string? url = null)
        {
            url ??= "https://www.saucedemo.com/cart.html"; // replace with your config if needed
            await _page.GotoAsync(url);
        }

        public ILocator InventoryItem()  => _page.Locator("[data-test='inventory-item']");
        public ILocator ItemName()       => _page.Locator("[data-test='inventory-item-name']");
        public ILocator CheckoutButton() => _page.Locator("[data-test='checkout']");
        public ILocator RemoveProduct(string slug) => _page.Locator($"[data-test='remove-{slug}']");

        public async Task RemoveItemAsync(string name)
        {
            var slug = Utils.ProductSlug(name);
            var removeButton = RemoveProduct(slug);
            await removeButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await removeButton.ClickAsync();
        }

        public async Task ClickCheckoutAsync()
        {
            var btn = CheckoutButton();
            await btn.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await btn.ClickAsync();
            await _page.WaitForURLAsync("**/checkout-step-one.html");
        }
    }
}
