using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmazonStoreTestProject.Utils
{
    public static class ChromeDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}

