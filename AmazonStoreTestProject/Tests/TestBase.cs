using OpenQA.Selenium;
using AmazonStoreTestProject.Utils;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;
using System.Text;

namespace AmazonStoreTestProject.Tests
{
    public abstract class TestBase
    {
        protected IWebDriver driver;

        private static readonly List<(string Name, string Status, string Message, string? ScreenshotPath)> Results
            = new List<(string Name, string Status, string Message, string? ScreenshotPath)>();

        [SetUp]
        public void Setup()
        {
            driver = FirefoxDriverFactory.CreateDriver();
        }

        [TearDown]
        public void TearDown()
        {
            var result = TestContext.CurrentContext.Result;
            var testName = TestContext.CurrentContext.Test.Name;
            var status = result.Outcome.Status.ToString();
            var message = result.Message ?? string.Empty;
            string? screenshotPath = null;

            if (result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = driver.TakeScreenshot();
                screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{testName}_failure.png");
                screenshot.SaveAsFile(screenshotPath);
                TestContext.AddTestAttachment(screenshotPath, "Failure Screenshot");
            }

            Results.Add((testName, status, message, screenshotPath));

            driver?.Quit();
            driver?.Dispose();
        }

        [OneTimeTearDown]
        public void GenerateHtmlReport()
        {
            var reportDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Reports");
            Directory.CreateDirectory(reportDir);
            var reportPath = Path.Combine(reportDir, "TestReport.html");

            var html = new StringBuilder();
            html.AppendLine("<html><head><title>Test Report</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial; }");
            html.AppendLine("table { border-collapse: collapse; width: 100%; }");
            html.AppendLine("th, td { border: 1px solid #ccc; padding: 6px; vertical-align: top; text-align: left; }");
            html.AppendLine(".pass { background: #c8e6c9; }");
            html.AppendLine(".fail { background: #ffcdd2; }");
            html.AppendLine("img { max-width: 300px; display: block; margin-top: 5px; }");
            html.AppendLine("</style>");
            html.AppendLine("</head><body><h2>Amazon Store Test Report</h2>");
            html.AppendLine("<table><tr><th>Test Name</th><th>Status</th><th>Message</th><th>Screenshot</th></tr>");

            foreach (var r in Results)
            {
                var css = r.Status.Equals("Passed", StringComparison.OrdinalIgnoreCase) ? "pass" : "fail";
                var message = r.Message?.Replace("\r\n", "<br>")
                                        .Replace("\n", "<br>")
                                        .Replace("\r", "") ?? "";

                string screenshotHtml = !string.IsNullOrEmpty(r.ScreenshotPath)
                    ? $"<a href='{r.ScreenshotPath}' target='_blank'><img src='{r.ScreenshotPath}' alt='screenshot' /></a>"
                    : string.Empty;

                html.AppendLine($@"
                <tr class='{css}'>
                <td>{r.Name}</td>
                <td>{r.Status}</td>
                <td>{message}</td>
                <td>{screenshotHtml}</td>
                </tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine($"<p>Generated on {DateTime.Now}</p>");
            html.AppendLine("</body></html>");

            File.WriteAllText(reportPath, html.ToString());
            TestContext.AddTestAttachment(reportPath, "HTML Test Report");
        }
    }
}
