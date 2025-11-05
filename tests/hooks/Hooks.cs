using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using BoDi;

namespace MyTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            // Create Playwright instance
            _playwright = await Playwright.CreateAsync();

            // Launch a new browser instance (headless by default)
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                Args = new[] { "--start-maximized" }
            });

            // Create an isolated browser context per scenario
            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = null // Use full window size
            });

            // Open a fresh page for this scenario
            _page = await _context.NewPageAsync();

            // Register page for dependency injection
            _container.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            // Clean up in reverse order
            if (_context != null)
            {
                await _context.CloseAsync();
                _context = null;
            }

            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }

            _playwright?.Dispose();
        }
    }
}
