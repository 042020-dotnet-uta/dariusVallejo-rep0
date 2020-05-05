using Microsoft.EntityFrameworkCore;
using p0;
using Xunit;

namespace p0_test
{
    public class CustomerTest
    {
        [Fact]
        public void TestCustomerCreation()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                            .UseInMemoryDatabase(databaseName: "test_create_customer_customer")
                            .Options;
            using (var bc = new BusinessContext(options))
            {
                CustomerManager manager = new CustomerManager(new BusinessContext(options));
                Customer created = manager.create("New", "Customer");
                Assert.NotNull(created);
                Assert.Equal("New", created.firstName);
            }
        }

        [Fact]
        public void TestCustomerLogin()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_login_customer")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                CustomerManager manager = new CustomerManager(bc);
                Customer created = manager.create("New", "Customer");
                Assert.NotNull(created);
                Assert.Equal("New", created.firstName);

                Customer login = manager.login("New", "Customer");
                Assert.NotNull(login);
                Assert.Equal(created.CustomerId, login.CustomerId);

            }
        }

        [Fact]
        public void TestCustomerLoginFail()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_login_customer_fail")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                CustomerManager manager = new CustomerManager(bc);
                Customer created = manager.create("New", "Customer");
                Assert.NotNull(created);
                Assert.Equal("New", created.firstName);

                Customer missing = manager.login("Missing", "Customer");
                Assert.Null(missing);
            }
        }
    }
}
