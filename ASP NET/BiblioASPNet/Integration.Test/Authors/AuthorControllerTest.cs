using BiblioASPNet.Application.Data.Context; // Substitua pelo namespace do seu DbContext
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Net;
using TestUtils.Request.Authors;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using BiblioASPNet.Application.Responses;

namespace Integration.Test.Authors
{
    public class AuthorControllerTest : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public AuthorControllerTest(TestWebApplicationFactory webApplicationFactory)
        {
  
            _httpClient = webApplicationFactory.CreateClient();

        }


        [Fact]
        public async Task CreatedOnCreatingAuthor()
        {
            var request = CreateAuthorRequestBuilder.Build();
            var result = await _httpClient.PostAsJsonAsync("api/Author", request);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task BadRequestOnCreatingAuthorWithEmptyName(string name)
        {
            var request = CreateAuthorRequestBuilder.Build("name", name);
            var result = await _httpClient.PostAsJsonAsync("api/Author", request);
            var responseBody = await result.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Contains("O campo Name não pode ser nulo ou vazio.", responseBody);
        }


        [Fact]
        public async Task BadRequestOnCreatingAuthorWithAnameWithLessThan3Caracthers()
        {
            var request = CreateAuthorRequestBuilder.Build("name", "12");
            var result = await _httpClient.PostAsJsonAsync("api/Author", request);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
