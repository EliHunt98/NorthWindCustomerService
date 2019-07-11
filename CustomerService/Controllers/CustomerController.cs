using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CustomerService.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using CustomerService.Providers;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class CustomerController : ControllerBase
    {

        private readonly ICustomerProvider customerProvider;

        public CustomerController(ICustomerProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }

        [HttpGet("{Country}")]
        public async Task<List<Customer>> GetCustomer(string Country)
        {

            return await customerProvider.GetCustomer(Country);
        }

        [HttpPost("")]
        public async Task<ActionResult<HttpStatusCode>> CreateCustomer([FromBody] Customer customer)
        {
            return await customerProvider.CreateCustomer(customer);

        }

        [HttpPut("{customerID}")]
        public async Task<ActionResult<HttpStatusCode>> UpdateCustomer([FromBody] Customer customer, string customerID)
        {
            return await customerProvider.UpdateCustomer(customer, customerID);
        }

        [HttpDelete("{customerID}")]
        public async Task<ActionResult<HttpStatusCode>> DeleteCustomer(string customerID)
        {
            return await customerProvider.DeleteCustomer(customerID);
        }
    }
}