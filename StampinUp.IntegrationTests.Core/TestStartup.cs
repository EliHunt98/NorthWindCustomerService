using NUnit.Framework;
using StampinUp.Core.Testing.Web;
using System.Diagnostics.CodeAnalysis;

namespace StampinUp.Core.IntegrationTests
{
    

    
        [SetUpFixture]
        public class TestStartup
        {
            [OneTimeSetUp]
            public void SetUp()
            {
                WebTestManager.Initialize<TestHostStartup>("CustomerService");
            }
        }
    }

