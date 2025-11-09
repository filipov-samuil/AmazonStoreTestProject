using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AmazonStoreTestProject.Utils
{
    public static class FirefoxDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new FirefoxOptions();
            var driver = new FirefoxDriver(options);

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}

