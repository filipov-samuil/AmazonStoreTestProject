using OpenQA.Selenium;
using AmazonStoreTestProject.Utils;
using OpenQA.Selenium.Support.Extensions;

namespace AmazonStoreTestProject.Tests
{
    public abstract class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = ChromeDriverFactory.CreateDriver();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = driver.TakeScreenshot();
                var filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "test_failure.png");
                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath);
            }

            driver?.Quit();
            driver?.Dispose();
        }
    }
}

