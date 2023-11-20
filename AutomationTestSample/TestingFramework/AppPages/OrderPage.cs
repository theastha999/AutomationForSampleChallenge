
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace AutomationTestSample
{
    public class OrderPage 
    {
        private IWebDriver _driver;
        protected WebDriverWait? Wait;

        [FindsBy(How = How.CssSelector , Using = "button[ng-reflect-router-link^='/new-order']")]
        public IWebElement? _createNew;

        [FindsBy(How = How.Name, Using = "Accession Number")]
        private IWebElement? _accessionNumber;


        public OrderPage(IWebDriver driver) 
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);


        }
        public void ClickOnCreateOrder()

        {
           
            _createNew?.Click();
        }
        public bool IsOrderItemDisplayed()
        {
            IWebElement orderItem = _driver.FindElement(By.XPath("//div[@class='order-item']"));
            return orderItem != null;
        }


        public static void ScrollPage(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollTillElementIsVisible(String  webElementID)
        {
            IWebElement targetElement = _driver.FindElement(By.Name(webElementID));
            while (!(targetElement.Displayed))
            {
                ScrollPage(_driver);
            }
        }

    }
}

