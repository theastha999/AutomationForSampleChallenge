
using AutomationTestSample.TestingFramework.Utils;
using Xunit.Abstractions;
using Serilog;


namespace AutomationTestSample.TestingFramework.Tests
{
    [Collection("Test Collection")]
    public class OrderTest : TestBase
    {

        public OrderTest(WebDriverFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        public void ValidateMandatoryFieldsForOrderForm()
        {

            // Navigate to the homepage.
            HomePage.LaunchApp();
            WaitHelpers.WaitForPageLoad(Driver, 5);
            WaitHelpers.WaitForElementToBeClickable(Driver, HomePage.orderbutton, 5);
            HomePage.NavigateToOrders();
            WaitHelpers.WaitForElementToBeClickable(Driver, OrderPage._createNew, 5);
            OrderPage.ClickOnCreateOrder();
            WaitHelpers.WaitForElementToBeClickable(Driver, NewOrderPage.mrn, 5);
            string accessionID = GenerateRandomNumber(6);

            NewOrderPage.EnterDetailsForNewOrder(GenerateRandomNumber(3), GenerateRandomNumber(5), GenerateRandomNumber(5), accessionID);
            NewOrderPage.SelectValueFromDatePicker("10/29/2023 10:00 AM");
            Assert.True(NewOrderPage.submitbutton?.Displayed);
            NewOrderPage.ClickOnSubmitButton();
            _output.WriteLine("Order is created");
            OrderPage.ScrollPage(Driver);
            RecordTestResult(currentTestName, TestResult.Pass);

        }
    }


}

