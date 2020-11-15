using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CheckSeparatorMVC.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

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

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
