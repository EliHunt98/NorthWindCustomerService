using CustomerService;
using CustomerService.Classes;
using CustomerService.Controllers;
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
    //[TestFixture, Category("CustomerUnitTests")]
    //class CustomerControllerUnitTests
    //{
    //    Mock<NorthwindContext> northwindContext;
    //    Mock<Customer> customer;
    //    Mock<CustomerController> customerController;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        northwindContext = new Mock<NorthwindContext>();
    //        customer = new Mock<Customer>();
    //        customerController = new Mock<CustomerController>();
    //    }

    //    [TestCase("ABCUI", "Mexico", "McDonduls", "Tom Erics")]
    //    public void CustomerController_CreateCustomer_Success(string CustomerID, string Country, string CompanyName, string ContactName)
    //    {
    //        customerController.Setup(c => c.CreateCustomer(It.IsAny<Customer>()))
    //            .ReturnsAsync(HttpStatusCode.OK);
    //    }

    //    [TestCase("", "Mexico", "McDonduls", "Tom Erics")]
    //    public void CustomerController_CreateCustomer_BadRequest(string CustomerID, string Country, string CompanyName, string ContactName)
    //    {
    //        customerController.Setup(c => c.CreateCustomer(It.IsAny<Customer>()))
    //            .ReturnsAsync(HttpStatusCode.BadRequest);
    //    }

    //    [TestCase("Mexico")]
    //    public void CustomerController_GetCustomer_Success(string Country)
    //    {
    //        customerController.Setup(c => c.GetCustomer(It.IsAny<string>))


    //    }

        //[TestCase("Mexico")]
        //public void CustomerController_UpdateCustomer_Success(string Country)
        //{
        //    customerController.Setup(c => c.GetCustomer(It.IsAny<>))


        //}

        //[TestCase("Mexico")]
        //public void CustomerController_DeleteCustomer_Success(string Country)
        //{
        //    customerController.Setup(c => c.GetCustomer(It.IsAny<>))


        //}

    //}
}
