using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomerService.Classes
{
    public interface ICustomer
    {
        string CustomerID { get; set; }
        string CompanyName { get; set; }
        string ContactName { get; set; }
        string Address { get; set; }
        string Country { get; set; }
        string City { get; set; }
    }
}