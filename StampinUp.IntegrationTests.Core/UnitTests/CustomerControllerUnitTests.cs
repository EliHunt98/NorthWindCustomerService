using CustomerService;
using CustomerService.Classes;
using CustomerService.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StampinUp.Core.IntegrationTests.UnitTests
{
    [TestFixture, Category("CustomerUnitTests")]
    class CustomerControllerUnitTests
    {
        Mock<NorthwindContext> northwindContext;
        Mock<Customer> customer;
        Mock<CustomerController> customerController;

        [SetUp]
        public void SetUp()
        {
            northwindContext = new Mock<NorthwindContext>();
            customer = new Mock<Customer>();
            customerController = new Mock<CustomerController>();
        }

        [TestCase("ABCUI", "")]
        public void CustomerController_CreateCustomer_Success()
        {
            customerController.Setup(c => c.CreateCustomer(It.IsAny<Customer>()));
        }

    }
}
