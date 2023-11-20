
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationTestSample
{
    public class NewOrderPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "mrn")]
        public IWebElement? mrn;

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement? firstname;

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement? lastname;

        [FindsBy(How = How.Id, Using = "accession-number")]
        public IWebElement? accessionnumber;

        [FindsBy(How = How.Id, Using = "org-code")]
        public IWebElement? orgcode;

        [FindsBy(How = How.Id, Using = "site-id")]
        public IWebElement? siteid;

        [FindsBy(How = How.Id, Using = "modality")]
        public IWebElement? modality;

        [FindsBy(How = How.Id, Using = "study-date-time")]
        public IWebElement? studydatetime;

        [FindsBy(How = How.XPath, Using = "//app-new-order/form/div/div[2]/div/button[1]")]
        public IWebElement? submitbutton;


        [FindsBy(How = How.XPath, Using = "//app-new-order/form/div/div[2]/div/button[1]")]
        public IWebElement? firstName;

        public NewOrderPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterDetailsForNewOrder(string mrnvalue, string patientfirstname, string patientlastname, string accessionid)
        {
            mrn?.SendKeys(mrnvalue);
            firstname?.SendKeys(patientfirstname);
            lastname?.SendKeys(patientfirstname);
            accessionnumber?.SendKeys(accessionid);
            SelectValueFromDropDown(orgcode, "LUM");
            SelectValueFromDropDown(siteid, "102");
            SelectValueFromDropDown(modality, "CT");

        }

        public void ClickOnSubmitButton()
        {
            submitbutton?.Click();
        }
        public void SelectValueFromDropDown(IWebElement? dropdownelement, string optionvalue)
        {
            SelectElement selectElement = new SelectElement(dropdownelement);
            selectElement.SelectByValue(optionvalue);
        }
        public void SelectValueFromDatePicker(String dateandtime)
        {
            studydatetime?.Clear();
            studydatetime?.SendKeys(dateandtime);
        }


    }
}

