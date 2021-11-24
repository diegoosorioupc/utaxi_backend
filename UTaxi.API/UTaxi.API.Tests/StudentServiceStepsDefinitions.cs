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
    public class StudentServiceStepsDefinitions
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public StudentServiceStepsDefinitions(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/students is available")]
        public void GivenTheEndpointHttpsLocalhostApiVStudentsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"http://localhost:{port}/api/v{version}/students");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a Student Post Request is sent")]
        public async void WhenAStudentPostRequestIsSent(Table saveStudentResource)
        {
            var resource = saveStudentResource.CreateSet<SaveStudentResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }

        [Then(@"A response is received with status (.*)")]
        public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Student Resource is included in Response Body")]
        public async void ThenAStudentResourceIsIncludedInResponseBody(Table expectedStudentResource)
        {
            var expectedResource = expectedStudentResource.CreateSet<StudentResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<StudentResource>(responseData);
            Assert.Equal(expectedResource.Name, resource.Name);
        }
    }
}