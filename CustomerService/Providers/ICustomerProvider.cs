using CustomerService.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerService.Providers
{
    public interface ICustomerProvider
    {

        Task<List<Customer>> GetCustomer(string Country);
        Task<HttpStatusCode> CreateCustomer(Customer customer);
        Task<HttpStatusCode> UpdateCustomer(Customer customer, string customerID);
        Task<HttpStatusCode> DeleteCustomer(string customerID);
    }
}
