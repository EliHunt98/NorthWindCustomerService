using NUnit.Framework;
using StampinUp.Core.Testing.Web;
using System.Diagnostics.CodeAnalysis;

namespace StampinUp.Core.IntegrationTests
{
    

    namespace StampinUp.Testing.IntegrationTests
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
}
