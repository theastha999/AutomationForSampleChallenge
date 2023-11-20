using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AutomationTestSample.TestingFramework.Utils;

namespace AutomationTestSample
{
    public class HomePage
    {
        private IWebDriver? _driver;

        [FindsBy(How = How.LinkText, Using = "Orders")]
        public IWebElement? orderbutton;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void LaunchApp()
        {
            _driver?.Navigate().GoToUrl(TestConfig.BaseUrl);
        }

        public void NavigateToOrders()
        {

            orderbutton?.Click();
        }

    }
}
