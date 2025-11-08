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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var cart = wait.Until(ExpectedConditions.ElementToBeClickable(cartButton));
            cart.Click();
        }

        public bool IsItemInCart(string expectedTitle)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("div.sc-list-item")).Count > 0);

            var allTitleElements = driver.FindElements(By.CssSelector("span.a-truncate-full.a-offscreen"));

            Console.WriteLine($"Found {allTitleElements.Count} title elements in the cart.");

            foreach (var titleElement in allTitleElements)
            {
                string title = titleElement.Text.Trim();
                Console.WriteLine($"Cart item text: '{title}'");

                if (title.Contains(expectedTitle, StringComparison.OrdinalIgnoreCase) ||
                    expectedTitle.Contains(title, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            Console.WriteLine($"No match found for '{expectedTitle}'");
            return false;
        }
    }
}
