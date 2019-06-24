using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StampinUp.Core.AspNetCore.WebHosting;

namespace CustomerService
{
    public static class Program
    {
        public static void Main(string[] args) => CoreWebHost.UseStartup<Startup>(args: args).Build().Run();
    }
}
