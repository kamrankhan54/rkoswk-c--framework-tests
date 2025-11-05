// Hooks/Hooks.cs
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using BoDi; // SpecFlow's built-in DI container
using MyTests.Pages;

namespace MyTests.Hooks;

[Binding]
public sealed class Hooks
{
    private readonly IObjectContainer _container;
    private IBrowser _browser;
    private IPage _page;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario(Order = 0)]
    public async Task SetupPlaywrightAsync()
    {
        // Launch a browser
        var playwright = await Playwright.CreateAsync();
       _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });


        // Create a new browser context and page
        var context = await _browser.NewContextAsync();
        _page = await context.NewPageAsync();

        // Register instances so SpecFlow can inject them
        _container.RegisterInstanceAs(_browser);
        _container.RegisterInstanceAs(context);
        _container.RegisterInstanceAs(_page);

        // Register your Page Objects (equivalent to Playwright fixtures)
        _container.RegisterInstanceAs(new LoginPage(_page, "https://www.saucedemo.com/"));
        _container.RegisterInstanceAs(new CartPage(_page, "https://www.saucedemo.com/cart.html"));
        _container.RegisterInstanceAs(new InventoryPage(_page));
        _container.RegisterInstanceAs(new CheckoutPages(_page));
        _container.RegisterInstanceAs(new ProductDetailPage(_page));
    }

    [AfterScenario]
    public async Task TearDownAsync()
    {
        if (_page != null)
            await _page.CloseAsync();

        if (_browser != null)
            await _browser.CloseAsync();
    }
}
