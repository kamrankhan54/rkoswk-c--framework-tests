// LoginPage.cs
using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace MyTests.Pages;

public sealed class LoginPage
{
    private readonly IPage _page;
    private readonly string _loginPageUrl;

    public LoginPage(IPage page, string loginPageUrl)
    {
        _page = page;
        _loginPageUrl = loginPageUrl;
    }

    // NAVIGATION
    public Task OpenAsync() => _page.GotoAsync(_loginPageUrl);

    // LOCATORS
    public ILocator UsernameInput => _page.Locator("input[data-test=\"username\"]");
    public ILocator PasswordInput => _page.Locator("input[data-test=\"password\"]");
    public ILocator LoginButton   => _page.Locator("input[data-test=\"login-button\"]");
    public ILocator ErrorMessage  => _page.Locator("[data-test=\"error\"]");

    // ACTIONS
    public async Task LoginAsync(string username, string password)
    {
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);
        await LoginButton.ClickAsync();
    }

    // VALIDATIONS
    public async Task ExpectErrorVisibleAsync(string errorText)
    {
        await Expect(ErrorMessage).ToContainTextAsync(errorText);
    }

    public async Task ExpectOnInventoryPageAsync()
    {
        await Expect(_page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex("inventory\\.html"));
    }
}
