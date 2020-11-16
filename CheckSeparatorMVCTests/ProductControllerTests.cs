using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CheckSeparatorMVC.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using CheckSeparatorMVCTests.Classes;

namespace CheckSeparatorMVCTests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<CheckSeparatorMVC.Startup>>
    {
        private readonly WebApplicationFactory<CheckSeparatorMVC.Startup> factory;

        public ProductControllerTests(WebApplicationFactory<CheckSeparatorMVC.Startup> factory)
        {
            this.factory = factory;
        }

        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = factory.CreateClient();

            var response = client.GetAsync(url);

            //response.EnsureSuccessStatusCode(); // Status Code 200-299
            //Assert.Equal("text/html; charset=utf-8",
            //    response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Get_SecurePageIsReturnedForAnAuthenticatedUser()
        {
            // Arrange
            var client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "Test", options => { });
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false,
                });

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Test");

            //Act
            var response = await client.GetAsync("/SecurePage");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
