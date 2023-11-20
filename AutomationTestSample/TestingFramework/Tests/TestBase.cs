
using AutomationTestSample.TestingFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationTestSample.TestingFramework.Reports;
using Xunit.Abstractions;
using AventStack.ExtentReports;


namespace AutomationTestSample.TestingFramework.Tests
{
    public class TestBase : IDisposable, IClassFixture<WebDriverFixture>
    {
        protected IWebDriver Driver;

        protected OrderPage OrderPage;
        protected HomePage HomePage;
        protected NewOrderPage NewOrderPage;
        protected WebDriverWait? Wait;
        public ExtentTest? CurrentTest { get; private set; }
        protected string currentTestName;
        public  ITestOutputHelper _output;
        private static readonly Dictionary<string, TestResult> testResults = new Dictionary<string, TestResult>();

        // You can add more common page objects or elements here

        public TestBase(WebDriverFixture fixture, ITestOutputHelper outputHelper)
        {

            Driver = fixture.Driver;
            _output = outputHelper;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            OrderPage = new OrderPage(Driver);
            HomePage = new HomePage(Driver);
            NewOrderPage = new NewOrderPage(Driver);
            WaitHelpers.WaitForPageLoad(Driver, 10);
            currentTestName = _output.GetTestName();
            CurrentTest = ExtentReportUtils.extent.CreateTest(currentTestName);
            RecordstResult(currentTestName, TestResult.Unknown);

        }


        public static string GenerateRandomNumber(int length)
        {
            Random random = new Random();
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += random.Next(0, 10).ToString(); // Generates a random digit between 0 and 9
            }

            return result;
        }

        protected void RecordTestResult(string testname , TestResult testresult)
        {
            testResults[testname] = testresult;
        }

        
        public void Dispose()
        {
            TestResult currentTestResult = testResults.GetValueOrDefault(currentTestName);
            switch (currentTestResult)
            {
                case TestResult.Pass:
                    CurrentTest?.Log(Status.Pass, currentTestName + "run successfully");
                    break;

                case TestResult.Fail:
                    CurrentTest?.Log(Status.Fail, currentTestName + "run Failed");
                    break;
                case TestResult.Unknown:
                    CurrentTest?.Log(Status.Fail, currentTestName + "run Failed");
                    break;
            }

           
            Driver.Quit();
        }

        protected void RecordstResult(string testName ,TestResult testResult)
        {
            testResults[testName] = testResult;
        }
        public enum TestResult
        {
            Pass,
            Fail,
            Unknown

        }
    }
}