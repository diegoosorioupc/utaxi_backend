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
    public class PaymentServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public PaymentServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/payments is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPaymentsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"http://localhost:{port}/api/v{version}/payments");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a new payment request is sent")]
        public async void WhenANewPaymentRequestIsSent(Table savePaymentResource)
        {
            var resource = savePaymentResource.CreateSet<SavePaymentResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }

        [Then(@"Response receipt with status (.*)")]
        public void ThenResponseReceiptWithStatus(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Payment Resource is included in Response Body")]
        public async void ThenAPaymentResourceIsIncludedInResponseBody(Table expectedPaymentResource)
        {
            var expectedResource = expectedPaymentResource.CreateSet<PaymentResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<PaymentResource>(responseData);
            Assert.Equal(expectedResource.TypePayment, resource.TypePayment);
        }
    }
}