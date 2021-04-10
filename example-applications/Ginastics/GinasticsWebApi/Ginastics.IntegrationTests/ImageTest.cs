using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace Ginastics.IntegrationTests
{
    public class ImageTest
    {
        private readonly RestClient _httpClient = new();
        private const string Host = "https://localhost:5001";

        [Test]
        public async Task ShouldUploadImage()
        {
            var ginId = Guid.NewGuid();
            var imageRequest = new RestRequest($"{Host}/image/gin/{ginId}", Method.POST);
            imageRequest.AddFile("file", "images/skagerrak.png");

            var restResponse = await _httpClient.ExecuteAsync(imageRequest);
            restResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public async Task ShouldGetUploadedFile()
        {
            var ginId = Guid.NewGuid();
            var imageRequest = new RestRequest($"{Host}/image/gin/{ginId}", Method.POST);
            imageRequest.AddFile("file", "images/skagerrak.png");
            var restResponse = await _httpClient.ExecuteAsync(imageRequest);
            restResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var parameters = restResponse.Headers.First(c => c.Name.Equals("Location"));
            var getImageRequest = new RestRequest($"{Host}/{parameters.Value}", Method.GET);
            var imageResponse = await _httpClient.ExecuteAsync(getImageRequest);
            imageResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
            imageResponse.Content
                .Should()
                .NotBeNullOrEmpty();
        }
    }
}