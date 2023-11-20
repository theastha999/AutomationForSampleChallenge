using System;
using RestSharp;
namespace AutomationTestSample.TestingFramework.Utils
{
    public class APIClient
    {
        private readonly RestClient _client;
        public APIClient(string baseUrl)
        {
            _client = new RestClient(TestConfig.BaseUrl);
        }
        public RestResponse Get(string resource)
        {
            var request = new RestRequest(resource, Method.Get);

            return _client.Execute(request);
        }
        public RestResponse Post(string resource, object requestBody)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(requestBody);
            return _client.Execute(request);
        }

    }
}

