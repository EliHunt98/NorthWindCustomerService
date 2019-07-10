using CustomerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StampinUp.Core.AspNetCore.WebHosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StampinUp.Core.IntegrationTests
{
    class TestHostStartup : Startup
    {
        
        private readonly IConfiguration configuration;
        
        public TestHostStartup(IConfiguration configuration)
            : base(configuration)
        {
            this.configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
           

           
        }

       
        



    }
}
