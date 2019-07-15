using CustomerService;
using CustomerService.Classes;
using CustomerService.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using StampinUp.Core.IntegrationTests;
using StampinUp.Core.Testing.Web;
using StampinUp.Core.Testing.Web.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace CustomerServiceTests
{
    [TestFixture, Category("IntegrationTests_CustomerControler")]
    public class CustomerControllerTests 
    {
        private readonly string baseUri = "api/Customer";

        [OneTimeSetUp]
        public void SetUp()
        {
            WebTestManager.Initialize<TestHostStartup>("CustomerService");
        }

        [Test]
        [TestCase("Canada")]
        [TestCase("Mexico")]
        [TestCase("France")]
        [TestCase("UK")]
        public void CustomerController_GetCustomer_Success(string Country)
        {
            string getUri = $"{baseUri}/{Country}";
            TestHttpResponse testHttpResponse = WebTestManager.HttpClient.GET(getUri).Result;
            Assert.AreEqual(HttpStatusCode.OK, testHttpResponse.StatusCode);
        }

        [Test]
        [TestCase("Berry's Place", "Berry Thomas", "Mexico")]
        public void CustomerController_CreateCustomer_Success( string CompanyName, string ContactName, string Country)
        {
            WebTestManager.HttpClient.UsingTestServiceClient(httpClient =>
            {
                Customer req = new Customer
                {
                    CustomerID = System.Guid.NewGuid().ToString().Substring(0, 5),
                    CompanyName = CompanyName,
                    ContactName = ContactName,
                    Country = Country
                };

                StringContent postContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{baseUri}", postContent).Result;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            });
        }

        [Test]
        [TestCase("Berry's Place", "Claire Thomas", "Mexico")]
        public void CustomerController_DeleteCustomer_Success(string CompanyName, string ContactName, string Country)
        {
            WebTestManager.HttpClient.UsingTestServiceClient(httpClient =>
            {
                Customer req = new Customer
                {
                    CustomerID = System.Guid.NewGuid().ToString().Substring(0, 5),
                    CompanyName = CompanyName,
                    ContactName = ContactName,
                    Country = Country
                };

                StringContent postContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage postResponse = httpClient.PostAsync($"{baseUri}", postContent).Result;
                Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);
               
                HttpResponseMessage delResponse = httpClient.DeleteAsync($"{baseUri}/{req.CustomerID}").Result;
                Assert.AreEqual(HttpStatusCode.OK, delResponse.StatusCode);
            });
        }

        [Test]
        [TestCase("Berry's Place", "Claire Thomas", "Mexico", "123 Address", "Mark's")]
        public void CustomerController_UpdateCustomer_Success(string CompanyName, string ContactName, string Country,  string Address, string newCompanyName)
        {
            WebTestManager.HttpClient.UsingTestServiceClient(httpClient =>
            {
                Customer req = new Customer
                {
                    CustomerID = System.Guid.NewGuid().ToString().Substring(0, 5),
                    CompanyName = CompanyName,
                    ContactName = ContactName,
                    Country = Country,
                    Address = Address
                };
                
                StringContent postContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage postResponse = httpClient.PostAsync($"{baseUri}", postContent).Result;
                Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

                //req.CompanyName = newCompanyName;
                StringContent putContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage putResponse = httpClient.PutAsync($"{baseUri}/{req.CustomerID}", putContent).Result;
                Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);

                

            });
        }

    }



    
}
