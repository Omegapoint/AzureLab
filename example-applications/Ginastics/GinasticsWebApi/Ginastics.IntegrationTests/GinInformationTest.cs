using System;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Ginastics.Api;
using NUnit.Framework;
using RestSharp;

namespace Ginastics.IntegrationTests
{
    public class GinInformationTest
    {
        private readonly RestClient _httpClient = new();
        private const string Host = "https://localhost:5001";

        [Test]
        public void ShouldCreateGin()
        {
            var request = new RestRequest(new Uri($"{Host}/gin"), Method.POST, DataFormat.Json);
            request.AddJsonBody(GivenGinInformation());
            var response = _httpClient.Post<GinInformation>(request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldGetAllGin()
        {
            var request = new RestRequest(new Uri($"{Host}/gin"), Method.GET, DataFormat.Json);
            var response = _httpClient.Get<GinInformation>(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Test]
        public void ShouldGetGin()
        {
            var id = Guid.NewGuid();
            var request = new RestRequest(new Uri($"{Host}/gin/{id}"), Method.GET, DataFormat.Json);
            var response = _httpClient.Get<GinInformation>(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JsonSerializer.Deserialize<GinInformation>(response.Content).Should().Be(ExpectedGin());
        }
        
        [Test]
        public void ShouldDeleteGin()
        {
            var id = Guid.NewGuid();
            var request = new RestRequest(new Uri($"{Host}/gin/{id}"), Method.DELETE, DataFormat.Json);
            var response = _httpClient.Delete(request);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Test]
        public void ShouldModifyGin()
        {
            var id = Guid.NewGuid();
            var request = new RestRequest(new Uri($"{Host}/gin/{id}"), Method.PUT, DataFormat.Json);
            request.AddJsonBody(GivenGinInformation());
            var response = _httpClient.Put<GinInformation>(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        
        private static GinInformation GivenGinInformation()
        {
            return new("Hendricks", "1000", "swe", "hendricks");
        }
        
        private static GinInformation ExpectedGin()
        {
            return new ("Hendricks", "1000", "swe", "hendricks");
        }
    }
}