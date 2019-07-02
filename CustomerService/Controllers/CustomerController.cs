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

namespace CustomerService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController
    {
        private readonly NorthwindContext NorthwindContext;
        public DbContextOptionsBuilder optionsBuilder { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public CustomerController(NorthwindContext NorthwindContext)
        {
            this.NorthwindContext = NorthwindContext;
            this.optionsBuilder = optionsBuilder;
            this.Customers = Customers;
        }

        


        [HttpGet("{Country}")]
        public async Task<ActionResult<List<Customer>>> GetCustomer(string Country)
        {

            IQueryable<Customer> custQuery =
            from cust in NorthwindContext.Customers
            where cust.Country == Country
            select cust;


            return custQuery.ToList();
        }

        [HttpPost("")]
        public async Task<ActionResult<HttpStatusCode>> CreateCustomer([FromBody] Customer customer)
        {

            var customers = NorthwindContext.Set<Customer>();

            Customer customerJson = new Customer();

            customerJson.Address = "123";
            customerJson.CompanyName = "Alder's";
            customerJson.ContactName = "Alder";
            customerJson.CustomerID = "EDCBB";
            customerJson.Country = "Mexico";

            string output = JsonConvert.SerializeObject(customerJson);


            //Customer deserializedCustomer = JsonConvert.DeserializeObject<Customer>(output);

            await customers.AddAsync(customerJson);

            NorthwindContext.SaveChanges();

            return HttpStatusCode.OK;


        }

        [HttpPut("{customerID}")]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer, string customerID)
        {
            var customerToChange = (from cust in NorthwindContext.Customers
                                    where customer.CustomerID == customerID
                                    select customer).FirstOrDefault();

            customerToChange.CompanyName = "Joes Noodles";
            customerToChange.ContactName = "Joe";
            customerToChange.Country = "Mexico";

            NorthwindContext.Update(customerToChange);
            NorthwindContext.SaveChanges();

            return customerToChange;
        }

        [HttpDelete("{customerID}")]
        public async Task<ActionResult<HttpStatusCode>> DeleteCustomer(string customerID)
        {
            var customerToDelete = (from customer in NorthwindContext.Customers
                                    where customer.CustomerID == customerID
                                    select customer).FirstOrDefault();

            NorthwindContext.Remove(customerToDelete);

            NorthwindContext.SaveChanges();

            return HttpStatusCode.OK;
        }
    }
}