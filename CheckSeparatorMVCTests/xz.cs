//using CheckSeparatorMVC;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using Xunit;

//namespace CheckSeparatorMVCTests
//{
//    public class TestFixture : IClassFixture<WebApplicationFactory<Startup>>
//    {
//        protected readonly WebApplicationFactory<Startup> Factory;
//        protected HttpClient Client;

//        public TestFixture(WebApplicationFactory<Startup> factory)
//        {
//            Factory = factory;
//            SetupClient();
//        }

//        protected static HttpContent ConvertToHttpContent<T>(T data)
//        {
//            var jsonQuery = JsonConvert.SerializeObject(data);
//            HttpContent httpContent = new StringContent(jsonQuery, Encoding.UTF8);
//            httpContent.Headers.Remove("content-type");
//            httpContent.Headers.Add("content-type", "application/json; charset=utf-8");

//            return httpContent;
//        }

//        private void SetupClient()
//        {
//            Client = Factory.WithWebHostBuilder(builder =>
//            {
//                /* I am telling builder to use appsettings.Integration,
//                that is correctly set up in my DevOps pipeline */
//                builder.UseEnvironment("Integration");
//                var configuration = new ConfigurationBuilder()
//                    .AddJsonFile("appsettings.Integration.json")
//                    .Build();

//                builder.ConfigureTestServices(services =>
//                {
//                    /* setup whatever services you need to override, 
//                    its useful for overriding db context if you're using Entity Framework */
//                    var dbConnectionString = configuration.GetSection("ConnectionStrings")["TheConnectionString"];

//                    services.AddDbContext<DbContext>(optionsBuilder =>
//                    {
//                        optionsBuilder.UseSqlServer(dbConnectionString);
//                    });

//                    /* Overriding policies and adding Test Scheme defined in TestAuthHandler */
//                    services.AddMvc(options =>
//                    {
//                        var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme)
//                            .RequireAuthenticatedUser()
//                            .AddAuthenticationSchemes("Test")
//                            .Build();

//                        options.Filters.Add(new AuthorizeFilter(policy));
//                    });

//                    /* Adding Default Authentication schemes
//                        This is enough to prevent unauthorized client (if you wish to have that kind of tests) */
//                    services.AddAuthentication(options =>
//                    {
//                        options.DefaultAuthenticateScheme = "Test";
//                        options.DefaultChallengeScheme = "Test";
//                        options.DefaultScheme = "Test";
//                    })
//                    /* Here we're adding TestAuthentication Scheme with Handler that will Authenticate our client based on Claims */
//                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
//                })
//                .CreateClient(new WebApplicationFactoryClientOptions
//                {
//                    AllowAutoRedirect = false
//                });
//            }
//        }
//    }
//}