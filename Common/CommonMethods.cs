using RestSharp;
using System;
using System.IO;

namespace TestProject.Common
{
    public class CommonMethods
    {
        private static RestClient _client;
        private static RestRequest _restRequest;
        private static readonly string _baseUri = "https://reqres.in/api";

        public static RestClient GetRestClient(string endPoint)
        {
            var url = string.Concat(_baseUri + endPoint);
            return _client = new RestClient(url);
        }

        public static RestRequest CreatePostRequest(Object obj)
        {
            _restRequest = new RestRequest(Method.POST)
            {
                UseDefaultCredentials = true,
            };
            _restRequest.AddJsonBody(obj);
            return _restRequest;
        }

        public static RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET)
            {
                UseDefaultCredentials = true,
            };
            return _restRequest;
        }
    }
}
