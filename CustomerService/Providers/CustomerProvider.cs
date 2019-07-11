using CustomerService.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerService.Providers
{
    public class CustomerProvider : ICustomerProvider
    {

        private readonly NorthwindContext NorthwindContext;
        public DbContextOptionsBuilder optionsBuilder { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public CustomerProvider(NorthwindContext NorthwindContext)
        {
            this.NorthwindContext = NorthwindContext;
            this.optionsBuilder = optionsBuilder;
            this.Customers = Customers;
        }

        public async Task<List<Customer>> GetCustomer(string Country)
        {
            IQueryable<Customer> custQuery =
            from cust in NorthwindContext.Customers
            where cust.Country == Country
            select cust;

            return custQuery.ToList();
        }

       
        public async Task<HttpStatusCode> CreateCustomer(Customer customer)
        {
            var customers = NorthwindContext.Set<Customer>();

            Customer customerJson = new Customer();
            customerJson.CustomerID = string.IsNullOrEmpty(customer.CustomerID) ? System.Guid.NewGuid().ToString().Substring(0, 5) : customer.CustomerID;
            customerJson.CompanyName = "Alder's";
            customerJson.ContactName = "Alder";
            customerJson.Country = "Mexico";

            string output = JsonConvert.SerializeObject(customerJson);
            Customer deserializedCustomer = JsonConvert.DeserializeObject<Customer>(output);
            await customers.AddAsync(customerJson);
            NorthwindContext.SaveChanges();

            return HttpStatusCode.OK;
        }

       
        public async Task<HttpStatusCode> UpdateCustomer(Customer customer, string customerID)
        {
            var customerToChange = (from cust in NorthwindContext.Customers
                                    where customer.CustomerID == customerID
                                    select customer).FirstOrDefault();

            customerToChange.CompanyName = string.IsNullOrEmpty(customer.CustomerID) ? System.Guid.NewGuid().ToString().Substring(0, 5) : customer.CustomerID;
            customerToChange.ContactName = string.IsNullOrEmpty(customer.CustomerID) ? System.Guid.NewGuid().ToString().Substring(0, 5) : customer.ContactName;
            customerToChange.Country = string.IsNullOrEmpty(customer.CustomerID) ? System.Guid.NewGuid().ToString().Substring(0, 5) : customer.Country;

            NorthwindContext.Update(customerToChange);
            NorthwindContext.SaveChanges();

            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> DeleteCustomer(string customerID)
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
