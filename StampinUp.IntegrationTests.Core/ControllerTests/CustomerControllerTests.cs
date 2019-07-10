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
using System.Net;
using System.Net.Http;
using System.Text;

namespace CustomerServiceTests
{
    [TestFixture, Category("CustomerController")]
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
        [TestCase("POIOI", "Berry's Place", "Berry Thomas", "Mexico")]
        public void CustomerController_CreateCustomer_Success(string CustomerID, string CompanyName, string ContactName, string Country)
        {

            WebTestManager.HttpClient.UsingTestServiceClient(httpClient =>
            {
                Customer req = new Customer
                {
                    CustomerID = CustomerID,
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
        [TestCase("POIOO", "Berry's Place", "Claire Thomas", "Mexico")]
        public void CustomerController_DeleteCustomer_Success(string CustomerID, string CompanyName, string ContactName, string Country)
        {

            WebTestManager.HttpClient.UsingTestServiceClient(httpClient =>
            {
                Customer req = new Customer
                {
                    CustomerID = CustomerID,
                    CompanyName = CompanyName,
                    ContactName = ContactName,
                    Country = Country
                };

                StringContent postContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage postResponse = httpClient.PostAsync($"{baseUri}", postContent).Result;
                HttpResponseMessage delResponse = httpClient.DeleteAsync($"{baseUri}/{CustomerID}").Result;
                Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);
                Assert.AreEqual(HttpStatusCode.OK, delResponse);
            });
        }

        [Test]
        [TestCase("POIII", "Berry's Place", "Claire Thomas", "Mexico", "Mark's")]
        public void CustomerController_UpdateCustomer_Success(string CustomerID, string CompanyName, string ContactName, string Country, string newCompanyName)
        {

            WebTestManager.HttpClient.UsingTestServiceClient(httpClient =>
            {
                Customer req = new Customer
                {
                    CustomerID = CustomerID,
                    CompanyName = CompanyName,
                    ContactName = ContactName,
                    Country = Country
                };
                
                StringContent postContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage postResponse = httpClient.PostAsync($"{baseUri}", postContent).Result;
                Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

                req.CompanyName = newCompanyName;
                StringContent putContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                HttpResponseMessage putResponse = httpClient.PutAsync($"{baseUri}/{CustomerID}", putContent).Result;
                
                Assert.AreEqual(HttpStatusCode.OK, putResponse);
            });
        }
    }



    
}
