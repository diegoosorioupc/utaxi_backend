using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UTaxi.API.Resources;
using Xunit;

namespace UTaxi.API.Tests
{
    [Binding]
    public class DriverServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public DriverServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/drivers is available")]
        public void GivenTheEndpointHttpsLocalhostApiVDriversIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"http://localhost:{port}/api/v{version}/drivers");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a Post Request is sent")]
        public async void WhenAPostRequestIsSent(Table saveDriverResource)
        {
            var resource = saveDriverResource.CreateSet<SaveDriverResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Driver Resource is included in Response Body")]
        public async void ThenADriverResourceIsIncludedInResponseBody(Table expectedDriverResource)
        {
            var expectedResource = expectedDriverResource.CreateSet<DriverResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<DriverResource>(responseData);
            Assert.Equal(expectedResource.Name, resource.Name);
        }
    }
}