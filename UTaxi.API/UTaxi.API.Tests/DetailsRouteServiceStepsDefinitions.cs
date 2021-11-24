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
    public class DetailsRouteStepsDefinitions
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public DetailsRouteStepsDefinitions(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/detailsroute is available")]
        public void GivenTheEndpointHttpsLocalhostApiVDetailsrouteIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"http://localhost:{port}/api/v{version}/detailsroute");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a Post Request the detail is sent")]
        public async void WhenAPostRequestTheDetailIsSent(Table saveDetailsRouteResource)
        {
            var resource = saveDetailsRouteResource.CreateSet<SaveDetailsRouteResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }

        [Then(@"Response with Status (.*) is received")]
        public void ThenResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Details Route Resource is included in Response Body")]
        public async void ThenADetailsRouteResourceIsIncludedInResponseBody(Table expectedDetailsRouteResource)
        {
            var expectedResource = expectedDetailsRouteResource.CreateSet<DetailsRouteResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<DetailsRouteResource>(responseData);
            Assert.Equal(expectedResource.RouteCode, resource.RouteCode);
        }
    }
}