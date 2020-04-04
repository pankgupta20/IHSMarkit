using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TestProject.Common;
using TestProject.Objects;

namespace TestProject.APITest.Steps
{
    [Binding]
   public class UserRegistrationStepDef
    {
        private static RestClient _client;
        private static RestRequest _restRequest;

        [When(@"I send the '(.*)' and '(.*)' in the payload")]
        public void WhenISendTheAndInThePayload(string email, string password)
        {
            UserDetails userDetails = new UserDetails
            {
                Email = email,
                Password = password
            };

           _restRequest = CommonMethods.CreatePostRequest(userDetails);
        }

        [Then(@"Response is returned with code '(.*)'")]
        public void ThenResponseIsReturnedWithCode(string responseCode)
        {
            IRestResponse restResponse = _client.Execute(_restRequest);
            Assert.AreEqual(responseCode, restResponse.StatusCode.ToString(), "Expected status code: " + responseCode + " is not equal to Actual status code: " + restResponse.StatusCode.ToString());
        }

        [Given(@"I want to send a request on '(.*)'")]
        public void GivenIWantToSendARequestOn(string endpoint)
        {
            _client = CommonMethods.GetRestClient(endpoint);
        }

        [When(@"I send the request")]
        public void WhenISendTheRequest()
        {
            _restRequest = CommonMethods.CreateGetRequest();
        }
    }
}
