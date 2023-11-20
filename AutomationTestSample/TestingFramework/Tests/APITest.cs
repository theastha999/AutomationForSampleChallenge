
using AutomationTestSample.TestingFramework.Utils;

namespace AutomationTestSample.TestingFramework.Tests
{
    [Collection("Test Collection")]
    public class APITest
    {

        [Fact]
        public void PerformGetRequestForOrder()
        {
            var client = new APIClient("https://localhost:44449/");

            var getResponse = client.Get("api/Orders");

            Console.WriteLine(getResponse);
            //Assert.True(getResponse.IsSuccessful, "API request is successful");
            if (getResponse.IsSuccessful)
            {
                // Handle successful GET response
                Console.WriteLine(getResponse.Content);
            }

        }

        [Fact]
        public void PerformGetRequestForPatients()
        {
            var client = new APIClient("https://localhost:44449/");

            var getResponse = client.Get("api/Patients");

            Console.WriteLine(getResponse);
            //Assert.True(getResponse.IsSuccessful, "API request is successful");
            if (getResponse.IsSuccessful)
            {
                // Handle successful GET response
                Console.WriteLine(getResponse.Content);
            }


        }
    }
}

