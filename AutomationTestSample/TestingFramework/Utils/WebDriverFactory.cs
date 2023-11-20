
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationTestSample.TestingFramework.Utils
{
    public class WebDriverFixture : IClassFixture<WebDriverFactory>
    {
        public IWebDriver Driver { get; }


        public WebDriverFixture()

        {

            var browserType = TestConfig.BrowserType;
            if (string.IsNullOrWhiteSpace(browserType))
            {
                Log.Warning("Please specify Browser type");
                throw new ArgumentException("Browser type  path not specified in configuration.");
            }
            Driver = WebDriverFactory.CreateWebDriver(browserType);
            if (Driver == null)
            {
                Log.Error("Driver is Null");
                throw new Exception("Failed to initialize WebDriver.");
            }
        }




    }

    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserType)
        {
            Log.Information("Creating WebDriver...");

            // Initialize and configure your WebDriver instance (e.g., ChromeDriver).
            switch (browserType.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException("Invalid browser type specified in configuration.");
            }

        }


    }
}

