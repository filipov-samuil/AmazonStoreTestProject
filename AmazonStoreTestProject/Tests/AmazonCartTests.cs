using OpenQA.Selenium;
using AmazonStoreTestProject.Pages;
using AmazonStoreTestProject.Utils;
using OpenQA.Selenium.Support.Extensions;

namespace AmazonStoreTestProject.Tests
{
    public class AmazonCartTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = ChromeDriverFactory.CreateDriver();
        }

        [Test]
        public void AddBookToCart()
        {
            var AmazonHomePage = new HomePage(driver);
            var resultsPage = new SearchResultsPage(driver);
            var productPage = new ProductPage(driver);
            var cartPage = new CartPage(driver);
            var productName = "The Final Empire: Mistborn Book 1";

            AmazonHomePage.OpenHomePage();
            AmazonHomePage.SearchForItemInSearchBox(productName);
            resultsPage.ClickProductByName(productName);
            productPage.SelectHardcover();
            productPage.AddProductToCart();

            Assert.IsTrue(driver.PageSource.Contains("Added to Cart"), "Product was not added to cart.");

            cartPage.ClickOnCartButton();

            Assert.IsTrue(cartPage.IsItemInCart("Mistborn: The Final Empire"), "Book was not found in the cart!");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = driver.TakeScreenshot();
                var filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "test_failure.png");
                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath);
            }

            driver?.Quit();
            driver?.Dispose();
        }
    }
}
