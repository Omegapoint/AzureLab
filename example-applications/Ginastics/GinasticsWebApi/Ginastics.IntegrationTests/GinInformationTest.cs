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
            var restRequest = new RestRequest(new Uri($"{Host}/gin"), Method.POST, DataFormat.Json);
            restRequest.AddJsonBody(GivenGinInformation());
            var response = _httpClient.Post<GinCreateRequest>(restRequest);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            
            var gin = JsonSerializer.Deserialize<Gin>(response.Content);
            
            gin.Name.Should().Be(GivenGinInformation().Name);
            gin.Abv.Should().Be(GivenGinInformation().Abv);
            gin.Distillery.Should().Be(GivenGinInformation().Distillery);
            gin.Country.Should().Be(GivenGinInformation().Country);
        }


        [Test]
        public void ShouldGetAllGin()
        {
            var gin1 = GivenGinInDatabase();
            var gin2 = GivenGinInDatabase();
            var request = new RestRequest(new Uri($"{Host}/gin"), Method.GET, DataFormat.Json);
            var response = _httpClient.Get<AllGins>(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Gins.Should().Contain(new []{gin1, gin2});
        }

        [Test]
        public void ShouldGetCreatedGin()
        {
            var gin = GivenGinInDatabase();
            var request = new RestRequest(new Uri($"{Host}/gin/{gin.GinId}"), Method.GET, DataFormat.Json);
            var response = _httpClient.Get<GinCreateRequest>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldNotGetGin()
        {
            var id = Guid.NewGuid();
            var request = new RestRequest(new Uri($"{Host}/gin/{id}"), Method.GET, DataFormat.Json);
            var response = _httpClient.Get<GinCreateRequest>(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
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
            var response = _httpClient.Put<GinCreateRequest>(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        private static GinCreateRequest GivenGinInformation()
        {
            return new() {
                Name = "Hendricks", 
                Abv =  "1000", 
                Country = "swe", 
                Distillery = "hendricks"
            };
        }
        
        private Gin GivenGinInDatabase()
        {
            var restRequest = new RestRequest(new Uri($"{Host}/gin"), Method.POST, DataFormat.Json);
            restRequest.AddJsonBody(GivenGinInformation());
            var response = _httpClient.Post<GinCreateRequest>(restRequest);

            return JsonSerializer.Deserialize<Gin>(response.Content);
        }
    }
}