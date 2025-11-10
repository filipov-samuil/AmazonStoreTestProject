using OpenQA.Selenium;

namespace AmazonStoreTestProject.Pages
{
    public class SearchResultsPage
    {
        private readonly IWebDriver driver;

        private const string ProductTitleXPathPattern = "//span[text()='{0}']";

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickProductByName(string productName)
        {
            var productLocator = By.XPath(string.Format(ProductTitleXPathPattern, productName));
            var product = driver.FindElement(productLocator);
            product.Click();
        }
    }
}
