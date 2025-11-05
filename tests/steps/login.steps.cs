using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MyTests.Pages;

namespace MyTests.Steps;

[Binding]
public sealed class LoginSteps
{
    private readonly LoginPage _login;
    private readonly TestLoginData _data;

    public LoginSteps(LoginPage login)
    {
        _login = login;
        _data = LoadData();
    }

    [Given(@"I open the login page")]
    public async Task GivenIOpenTheLoginPage()
    {
        await _login.OpenAsync();
    }

    [When(@"I enter my ""(.*)"" username and password")]
    public async Task WhenIEnterMyUsernameAndPassword(string username)
    {
        await _login.LoginAsync(username, _data.Password);
    }

    [Then(@"I should be logged in successfully")]
    public async Task ThenIShouldBeLoggedInSuccessfully()
    {
        await _login.ExpectOnInventoryPageAsync();
    }

    [Then(@"I should not be logged in and see locked out message")]
    public async Task ThenIShouldSeeLockedOutMessage()
    {
        await _login.ExpectErrorVisibleAsync("Epic sadface: Sorry, this user has been locked out.");
    }

    // Minimal loader for password from data.json
    private static TestLoginData LoadData()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "data", "data.json");
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<TestLoginData>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new TestLoginData();
    }

    private sealed class TestLoginData
    {
        public string Password { get; set; } = string.Empty;
    }
}
