using AmazonStoreTestProject.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AmazonStoreTestProject.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;

        private readonly By cartButton = By.Id("nav-cart");

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnCartButton()
        {
            var cart = WaitUtils.WaitUntilClickable(driver, cartButton, TestConfig.TimeoutFiveSeconds);
            cart.Click();
        }

        public bool IsItemInCart(string expectedTitle)
        {
            WaitUtils.WaitUntilVisible(driver, By.CssSelector("div.sc-list-item"), TestConfig.TimeoutFiveSeconds);

            var allTitleElements = driver.FindElements(By.CssSelector("span.a-truncate-full.a-offscreen"));
            Console.WriteLine($"Found {allTitleElements.Count} title elements in the cart.");

            foreach (var titleElement in allTitleElements)
            {
                string title = titleElement.Text.Trim();

                if (title.Contains(expectedTitle, StringComparison.OrdinalIgnoreCase))              
                {
                    Console.WriteLine($"Match found.");
                    return true;
                }
            }

            Console.WriteLine($"No match found for '{expectedTitle}'");
            return false;
        }
    }
}
