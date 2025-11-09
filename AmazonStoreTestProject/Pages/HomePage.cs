using AmazonStoreTestProject.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AmazonStoreTestProject.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        private readonly By searchBox = By.Id("twotabsearchtextbox");
        private readonly By searchButton = By.Id("nav-search-submit-button");
        private readonly By continueButton = By.XPath("//button[contains(@class,'a-button-text') and text()='Continue shopping']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(TestConfig.BaseUrl);
            DismissModalIfPresent();
        }

        private void DismissModalIfPresent()
        {
            var modals = driver.FindElements(continueButton);
            if (modals.Count == 0)
            {
                Console.WriteLine("No modal to handle.");
                return;
            }

            try
            {
                var button = WaitUtils.WaitUntilClickable(driver, continueButton, TestConfig.TimeoutFiveSeconds);
                button.Click();
                Console.WriteLine("Modal dismissed.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Modal found but not clickable.");
            }
        }

        public void SearchForItemInSearchBox(string text)
        {
            var searchInput = WaitUtils.WaitUntilVisible(driver, searchBox, TestConfig.TimeoutTenSeconds);
            searchInput.Clear();
            searchInput.SendKeys(text);
            Console.WriteLine($"Entered search text: '{text}'");

            var searchBtn = WaitUtils.WaitUntilClickable(driver, searchButton, TestConfig.TimeoutFiveSeconds);
            searchBtn.Click();
            Console.WriteLine("Search button clicked.");
        }
    }
}
