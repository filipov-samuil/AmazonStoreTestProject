using AmazonStoreTestProject.Utils;
using OpenQA.Selenium;

namespace AmazonStoreTestProject.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;

        private readonly By cartButton = By.Id("nav-cart");
        private readonly By CartItemContent = By.CssSelector("div.sc-list-item-content");
        private readonly By CartItemTitles = By.CssSelector("div.sc-list-item-content a.sc-product-link");

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
            WaitUtils.WaitUntilVisible(driver, CartItemContent, TestConfig.TimeoutFiveSeconds);

            var allTitleElements = driver.FindElements(CartItemTitles)
                                         .Where(e => e.Displayed)
                                         .ToList();

            foreach (var titleElement in allTitleElements)
            {
                string title = titleElement.Text.Trim();

                if (title.Equals(expectedTitle, StringComparison.OrdinalIgnoreCase) ||
                    title.Contains(expectedTitle, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Match found.");
                    return true;
                }
            }

            Console.WriteLine($"No match found for '{expectedTitle}'");
            return false;
        }
    }
}
