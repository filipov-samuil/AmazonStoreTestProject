using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AmazonStoreTestProject.Utils
{
    public static class WaitUtils
    {
        public static IWebElement WaitUntilClickable(IWebDriver driver, By by, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static IWebElement WaitUntilVisible(IWebDriver driver, By by, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}

