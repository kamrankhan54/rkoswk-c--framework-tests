using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MyTests.Pages;

namespace MyTests.Steps;

[Binding]
public sealed class ProductSteps
{
    private readonly ProductDetailPage _product;

    public ProductSteps(ProductDetailPage product)
    {
        _product = product;
    }

    [Given(@"I go to the ""(.*)"" product page")]
    public async Task GivenIGoToTheProductPage(string name)
    {
        await _product.ViewProductPageAsync(name);
    }

    [Given(@"I add product to cart")]
    public async Task GivenIAddProductToCart()
    {
        await _product.AddItemToBasketAsync();
    }
}
