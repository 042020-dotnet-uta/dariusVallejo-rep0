using Microsoft.EntityFrameworkCore;
using p0;
using System.Collections.Generic;
using Xunit;

namespace p0_test
{
    public class UnitTest1
    {
        DbContextOptions<BusinessContext> options;

        [Fact]
        public void TestCustomerCreation()
        {
            options = new DbContextOptionsBuilder<BusinessContext>()
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
            options = new DbContextOptionsBuilder<BusinessContext>()
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
            options = new DbContextOptionsBuilder<BusinessContext>()
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

        [Fact]
        public void TestLocationDetails()
        {
            options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_location_details")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                Location location = new Location()
                {
                    LocationId = "some-location-id",
                    locationName = "some-location-name",
                };
                bc.Orders.Add(new Order() { OrderId = "some-order-id", LocationId = "some-location-id" });
                bc.Orders.Add(new Order() { OrderId = "another-order-id", LocationId = "some-location-id"});
                bc.Locations.Add(location);
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                List<Order> orders = infoManager.locationDetails("some-location-name");
                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void TestLocationDetailsFail()
        {
            options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_location_details_fail")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                Location location = new Location()
                {
                    LocationId = "some-location-id",
                    locationName = "some-location-name",
                };
                bc.Locations.Add(location);
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                List<Order> orders = infoManager.locationDetails("some-location-name");
                List<Order> invalid = infoManager.locationDetails("invalid-location-name");
                Assert.Empty(orders);
                Assert.Null(invalid);
            }
        }
    }
}
