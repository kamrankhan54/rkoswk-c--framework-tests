using System.Threading.Tasks;
using Microsoft.Playwright;

namespace MyTests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Option A: read from your existing data.json helper
        public async Task OpenAsync(string? url = null)
        {
            // If you already have a data provider/helper, call it here.
            // Example (adjust to your helper):
            url ??= "https://www.saucedemo.com/";
            await _page.GotoAsync(url);
        }

        public ILocator UsernameInput() => _page.Locator("input[data-test='username']");
        public ILocator PasswordInput() => _page.Locator("input[data-test='password']");
        public ILocator LoginButton()   => _page.Locator("input[data-test='login-button']");
        public ILocator ErrorMessage()  => _page.Locator("[data-test='error']");

        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput().FillAsync(username);
            await PasswordInput().FillAsync(password);
            await LoginButton().ClickAsync();
        }

        public async Task ExpectErrorVisibleAsync(string error)
        {
            await Assertions.Expect(ErrorMessage()).ToContainTextAsync(error);
        }

        public async Task ExpectOnInventoryPageAsync()
        {
            await _page.WaitForURLAsync("**/inventory.html");
        }
    }
}
