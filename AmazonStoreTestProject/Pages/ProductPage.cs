using OpenQA.Selenium;

namespace AmazonStoreTestProject.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver driver;

        private readonly By hardcoverButton = By.XPath("//span[text()='Hardcover']/ancestor::a | //span[text()='Hardcover']/ancestor::button");
        private readonly By addToCartButton = By.Id("add-to-cart-button");

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectHardcover()
        {
            var button = driver.FindElements(hardcoverButton).FirstOrDefault();
            button?.Click();
            Console.WriteLine("Hardcover selected.");
        }

        public void AddProductToCart()
        {
            driver.FindElement(addToCartButton).Click();
            Console.WriteLine("Add to Cart button clicked.");
        }
    }
}

