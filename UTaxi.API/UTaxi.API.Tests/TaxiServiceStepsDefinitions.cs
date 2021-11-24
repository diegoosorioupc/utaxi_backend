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
    public class TaxiServiceStepsDefinitions
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public TaxiServiceStepsDefinitions(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/taxis is available")]
        public void GivenTheEndpointHttpsLocalhostApiVTaxisIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"http://localhost:{port}/api/v{version}/taxis");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a Vehicle Post Request is sent")]
        public async void WhenAVehiclePostRequestIsSent(Table saveTaxiResource)
        {
            var resource = saveTaxiResource.CreateSet<SaveTaxiResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }

        [Then(@"A Response is received with status (.*)")]
        public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Taxi Resource is included in Response Body")]
        public async void ThenATaxiResourceIsIncludedInResponseBody(Table expectedTaxiResource)
        {
            var expectedResource = expectedTaxiResource.CreateSet<TaxiResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<TaxiResource>(responseData);
            Assert.Equal(expectedResource.Model, resource.Model);
        }
    }
}