using CustomerService;
using CustomerService.Classes;
using CustomerService.Controllers;
using CustomerService.Providers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StampinUp.Core.IntegrationTests.UnitTests
{
    [TestFixture, Category("UnitTests_CustomerController")]
    class CustomerControllerUnitTests
    {
        Mock<NorthwindContext> northwindContext;
        
        Mock<ICustomerProvider> customerProvider;

        [SetUp]
        public void SetUp()
        {
            northwindContext = new Mock<NorthwindContext>();
            
            customerProvider = new Mock<ICustomerProvider>();
        }

        [TestCase("Mexico")]
        public void CustomerController_GetCustomer_Success(string country)
        {
            customerProvider.Setup(c => c.GetCustomer(It.IsAny<string>()))
                .ReturnsAsync(new List<Customer>());



        }



        [TestCase("Mexico", "McDonduls", "Tom Erics")]
        public void CustomerController_CreateCustomer_Success(string Country, string CompanyName, string ContactName)
        {
            customerProvider.Setup(c => c.CreateCustomer(It.IsAny<Customer>()))
                .ReturnsAsync(HttpStatusCode.OK);
        }

        [TestCase("Mexico", "McDonduls", "Tom Erics")]
        public void CustomerController_CreateCustomer_BadRequest(string Country, string CompanyName, string ContactName)
        {
            customerProvider.Setup(c => c.CreateCustomer(It.IsAny<Customer>()))
                .ReturnsAsync(HttpStatusCode.BadRequest);
        }

        [TestCase("ALFKI")]
        public void CustomerController_DeleteCustomer_Success(string CustomerID)
        {
            customerProvider.Setup(c => c.DeleteCustomer(It.IsAny<string>()))
                .ReturnsAsync(HttpStatusCode.OK);
        }

        [TestCase("ALFK")]
        public void CustomerController_DeleteCustomer_BadRequest(string CustomerID)
        {
            customerProvider.Setup(c => c.DeleteCustomer(It.IsAny<string>()))
                .ReturnsAsync(HttpStatusCode.BadRequest);
        }

        


    }
}
