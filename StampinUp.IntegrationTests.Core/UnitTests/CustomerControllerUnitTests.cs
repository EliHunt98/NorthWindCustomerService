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

namespace StampinUp.Core.IntegrationTests.UnitTests
{
    [TestFixture, Category("CustomerUnitTests")]
    class CustomerControllerUnitTests
    {
        Mock<NorthwindContext> northwindContext;
        Mock<Customer> customer;
        Mock<ICustomerProvider> customerProvider;

        [SetUp]
        public void SetUp()
        {
            northwindContext = new Mock<NorthwindContext>();
            
            customerProvider = new Mock<ICustomerProvider>();
        }

        //[TestCase("Mexico")]
        //public void CustomerController_GetCustomer_Success(string country)
        //{
        //    customerProvider.Setup(c => c.GetCustomer(It.IsAny<Customer>))
        //        .ReturnAsync(HttpStatusCode.OK);



        //}



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



    }
}
