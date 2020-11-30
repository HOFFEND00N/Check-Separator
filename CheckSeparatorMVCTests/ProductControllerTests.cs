using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using CheckSeparatorMVCTests.Classes;
using System.Net.Http;
using CheckSeparatorMVCTests.Helpers;
using AngleSharp.Html.Dom;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckSeparatorMVCTests
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<CheckSeparatorMVC.Startup>>
    {
        private CustomWebApplicationFactory<CheckSeparatorMVC.Startup> factory;
        private HttpClient client;

        public ProductControllerTests(CustomWebApplicationFactory<CheckSeparatorMVC.Startup> factory)
        {
            this.factory = factory;
            //client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Account/Index")]
        [InlineData("/Account/Login")]
        [InlineData("/Account/Register")]
        [InlineData("/Products/Index")]
        [InlineData("/Products/ViewAddProduct?CheckId=1")]
        [InlineData("/Products/ViewAddUserToCheck?CheckId=1")]
        [InlineData("/Products/CalculateCheck")]
        [InlineData("/Products/CheckProducts?CheckId=1")]
        [InlineData("/Products/DeleteProduct/1")]
        [InlineData("/Products/EditProduct/1")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Account/Index")]
        [InlineData("/Account/Login")]
        [InlineData("/Account/Register")]
        [InlineData("/Products/Index")]
        [InlineData("/Products/ViewAddProduct?CheckId=1")]
        [InlineData("/Products/ViewAddUserToCheck?CheckId=1")]
        [InlineData("/Products/CalculateCheck")]
        [InlineData("/Products/CheckProducts?CheckId=1")]
        [InlineData("/Products/DeleteProduct/1")]
        [InlineData("/Products/EditProduct/1")]
        public async Task Get_PageIsReturnedForAnAuthenticatedUser(string url)
        {
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

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_AddProduct()
        {
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

            var defaultPage = await client.GetAsync("/Products/ViewAddProduct?CheckId=1");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);


            var response = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='AddProductFrom']"),
                (IHtmlInputElement)content.QuerySelector("input[id='AddProductBtn']"));


            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Products/CheckProducts?CheckId=1", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_EditProduct()
        {
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

            var defaultPage = await client.GetAsync("/Products/EditProduct/1");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);


            var response = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='EditProductForm']"),
                (IHtmlInputElement)content.QuerySelector("input[id='EditProductBtn']"));


            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Products/CheckProducts?CheckId=1", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_DeleteProduct()
        {
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

            var defaultPage = await client.GetAsync("/Products/DeleteProduct/1");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);


            var response = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='DeleteProductForm']"),
                (IHtmlInputElement)content.QuerySelector("input[id='DeleteProductBtn']"));


            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Products/CheckProducts?CheckId=1", response.Headers.Location.OriginalString);
        }
    }
}
