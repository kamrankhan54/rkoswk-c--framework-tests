// CheckoutPages.cs
using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace MyTests.Pages;

public sealed class CheckoutPages
{
    private readonly IPage _page;

    public CheckoutPages(IPage page) => _page = page;

    // Step 1 checkout locators
    public ILocator FirstName => _page.Locator("[data-test=\"firstName\"]");
    public ILocator LastName => _page.Locator("[data-test=\"lastName\"]");
    public ILocator Postcode => _page.Locator("[data-test=\"postalCode\"]");
    public ILocator Continue => _page.Locator("[data-test=\"continue\"]");

    // Step 2 checkout locators
    public ILocator ProductName => _page.Locator("[data-test=\"inventory-item-name\"]");
    public ILocator ProductDescription => _page.Locator("[data-test=\"inventory-item-name\"]"); // same selector as TS
    public ILocator ProductTitle => _page.Locator("[data-test=\"inventory-item-name\"]");       // same selector as TS
    public ILocator PaymentInfoValue => _page.Locator("[data-test=\"payment-info-value\"]");
    public ILocator ShippingInfoValue => _page.Locator("[data-test=\"shipping-info-value\"]");
    public ILocator Subtotal => _page.Locator("[data-test=\"subtotal-label\"]");
    public ILocator Tax => _page.Locator("[data-test=\"tax-label\"]");
    public ILocator Total => _page.Locator("[data-test=\"total-label\"]");
    public ILocator FinishButton => _page.Locator("[data-test=\"finish\"]");

    // Step 3 checkout
    public ILocator ThankYouMessage => _page.Locator("[data-test=\"complete-header\"]");

    // Step 1 checkout
    public async Task CompleteInformationAsync(string firstName, string lastName, string postalCode)
        {
            await _page.FillAsync("[data-test='firstName']", firstName);
            await _page.FillAsync("[data-test='lastName']", lastName);
            await _page.FillAsync("[data-test='postalCode']", postalCode);
        }

public async Task ClickContinueAsync()
{
    var continueButton = _page.Locator("[data-test='continue']");

    // Wait until the button is attached and visible
    await continueButton.WaitForAsync(new() 
    { 
        State = WaitForSelectorState.Visible, 
        Timeout = 10000 
    });

    // Scroll and click
    await continueButton.ScrollIntoViewIfNeededAsync();
    await continueButton.ClickAsync();

    // ✅ Wait for next page (checkout-step-two.html) to load instead
    await _page.WaitForURLAsync("**/checkout-step-two.html", new() { Timeout = 10000 });
}



    // Step 2 checkout
    public async Task ClickFinishAsync()
{
    var finishButton = _page.Locator("[data-test='finish']");
    await finishButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
    await finishButton.ClickAsync();
}


    public async Task CompleteInfoAsync(string firstName, string lastName, string postalCode)
{
    await _page.FillAsync("[data-test='firstName']", firstName);
    await _page.FillAsync("[data-test='lastName']", lastName);
    await _page.FillAsync("[data-test='postalCode']", postalCode);
}

}
