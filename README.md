AmazonStoreTestProject

Automated UI tests for Amazon using Selenium WebDriver and NUnit.

Project Structure:
- AmazonStoreTestProject.sln
- Pages/                      # Page Object Model classes
- Products/                   # Product definitions and handling
- Tests/                      # NUnit test classes
- Utils/                      # Driver factories, waits, config
- bin/Debug/net8.0/Reports    # Output folder for reports and screenshots

Prerequisites:
- .NET SDK 8.0 or higher
- Visual Studio 2022 or higher
- Firefox installed

Setup:
1. Clone the repo via GitHub CLI:
   gh repo clone filipov-samuil/AmazonStoreTestProject
2. Restore NuGet packages in Visual Studio (Right-click on solution → Restore NuGet Packages)
3. Build solution

Running Tests:
- Open Test Explorer in Visual Studio
- Click Run All
- Tests run in a Firefox browser
- Failed test screenshots and HTML report saved automatically

Reports:
- HTML report: bin/Debug/net8.0/Reports/TestReport.html
- Screenshots on failure available in the report

Notes:
- Tests rely on Amazon homepage layout and element IDs at the time of creation
