using CustomerService;
using CustomerService.Classes;
using CustomerService.Controllers;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
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


        [Test]
        [TestCase("Canada")]
        public void CustomerController_GetCustomer_NullReference(string Country)
        {


            string getUri = $"{baseUri}/{Country}";
            
            TestHttpResponse testHttpResponse = WebTestManager.HttpClient.GET(getUri).Result; //Not working because we aren't using a culture?

            //SavedAccountResponse getSavedAccountResponse = JsonConvert.DeserializeObject<SavedAccountResponse>(testHttpResponse.RawContent);
            //Assert.AreEqual((int)HttpStatusCode.OK, getSavedAccountResponse.StatusCode);
            //Assert.AreEqual(savedAccount.PaymentAccountId, getSavedAccountResponse.SavedAccounts.First().PaymentAccountId);
        }

        
        [Test]
        [TestCase("AAABB", "Jerry's Place", "Jerry Thomas", "Mexico")]
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
                Assert.AreEqual(HttpStatusCode.OK, response.IsSuccessStatusCode);
            });
        }
    }



    
}
