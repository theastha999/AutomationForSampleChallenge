using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


public static class WaitHelpers
{
    public static IWebElement WaitForElementToBeClickable(IWebDriver driver, IWebElement? element, int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }
}