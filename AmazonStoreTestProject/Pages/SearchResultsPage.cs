using OpenQA.Selenium;

namespace AmazonStoreTestProject.Pages
{
    public class SearchResultsPage
    {
        private readonly IWebDriver driver;

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickProductByName(string productName)
        {
            var product = driver.FindElement(By.XPath($"//span[text()='{productName}']"));
            product.Click();
        }
    }
}
