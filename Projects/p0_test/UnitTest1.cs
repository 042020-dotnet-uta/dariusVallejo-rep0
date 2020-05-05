using Microsoft.EntityFrameworkCore;
using p0;
using System;
using System.Linq;
using Xunit;

namespace p0_test
{
    public class UnitTest1
    {
        DbContextOptions<BusinessContext> options;

        public UnitTest1()
        {
            options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_customers")
                .Options;
        }

        [Fact]
        public void TestCustomerCreation()
        {
            using (var bc = new BusinessContext(options))
            {
                CustomerManager manager = new CustomerManager(new BusinessContext(options));
                Customer missing = manager.login("Missing", "Customer");
                Assert.Null(missing);

                Customer created = manager.create("New", "Customer");
                Assert.NotNull(created);
                Assert.Equal("New", created.firstName);
            }
        }

        [Fact]
        public void TestCustomerLogin()
        {
            using (var bc = new BusinessContext(options))
            {
                CustomerManager manager = new CustomerManager(bc);
                Customer created = manager.login("New", "Customer");
                Assert.NotNull(created);
                Assert.Equal("New", created.firstName);
            }
        }
    }
}
