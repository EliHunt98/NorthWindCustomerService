using CustomerService;
using CustomerService.Classes;
using CustomerService.Controllers;
using Moq;
using NUnit.Framework;
using StampinUp.Core.Testing.Web;
using StampinUp.Core.Testing.Web.Contracts;

namespace CustomerServiceTests
{
    [TestFixture, Category("CustomerController")]
    public class CustomerControllerTests
    {

        private readonly string baseUri = "api/customer";



        [TestCase("Canada")]
        public void AccountController_GetOneTimePaymentAccount_Success(string Country)
        {


            string getUri = $"{baseUri}/{Country}";

            TestHttpResponse testHttpResponse = WebTestManager.HttpClient.GET(getUri).Result;

            //SavedAccountResponse getSavedAccountResponse = JsonConvert.DeserializeObject<SavedAccountResponse>(testHttpResponse.RawContent);
            //Assert.AreEqual((int)HttpStatusCode.OK, getSavedAccountResponse.StatusCode);
            //Assert.AreEqual(savedAccount.PaymentAccountId, getSavedAccountResponse.SavedAccounts.First().PaymentAccountId);
        }

        [TestCase("Mexico")]
        [TestCase("Canada")]
        [TestCase("Sweden")]
        public void CustomerController_GetCustomer_Success(string Country) 
        {
            //How would you even access the Http Requests that you have in your project
            //Because this is a unit test, would you just access the methods instead?
            
            //What would we even need to mock if we are just trying to access
            //the methods within CustomerController

            //Assuming that we have mocked CustomerController, 
            //Why do I not have access to the variables and methods?

            //Are we asserting that the list it retrieves is not null?
            //Are we asserting that it returns a 200 HTTP Response?

            //If we are returning a 200 HTTPResponse, would that mean you have to 
            //create an httpClient using the System.Net.HTTP?

            //If you are creating a new httpClient, would you include
            //the httpClient in the Northwin Context or CustomerController itself

            //Looking at the Unit tests and integration tests on Azure
            //I see they are using httpclients to test so I assume I won't use them
            //because this is supposed to be a unit test.
            

        }

        [Test]
        public void CustomerController_CreateCustomer_Success()
        {


        }



    }



    
}
