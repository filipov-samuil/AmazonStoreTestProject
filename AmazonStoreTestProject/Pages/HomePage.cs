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
            driver.Navigate().GoToUrl("https://www.amazon.com");
            DismissModalIfPresent();
        }

        private void DismissModalIfPresent()
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
                var button = wait.Until(d => d.FindElement(continueButton));
                if (button.Displayed)
                {
                    button.Click();
                }
            }
            catch
            {
                // Modal not present, no action needed
            }
        }

        public void SearchForItemInSearchBox(string text)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var searchInput = wait.Until(ExpectedConditions.ElementIsVisible(searchBox));
            searchInput.SendKeys(text);

            var searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchBtn.Click();
        }
    }
}
