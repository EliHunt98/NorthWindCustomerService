using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomerService.Classes
{

    [JsonObject]
    public class Customer : ICustomer
    {
        
        [JsonProperty("CustomerID")]
        public string CustomerID { get; set; }

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty("ContactName")]
        public string ContactName { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        
    }



}