using Microsoft.EntityFrameworkCore;
using p0;
using System.Collections.Generic;
using Xunit;

namespace p0_test
{
    public class InfoTest
    {
        [Fact]
        public void TestLocationDetails()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_location_details")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                Location location = new Location()
                {
                    LocationId = "some-location-id",
                    LocationName = "some-location-name",
                };
                bc.Orders.Add(new Order() { OrderId = "some-order-id", LocationId = "some-location-id" });
                bc.Orders.Add(new Order() { OrderId = "another-order-id", LocationId = "some-location-id" });
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
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_location_details_fail")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                Location location = new Location()
                {
                    LocationId = "some-location-id",
                    LocationName = "some-location-name",
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

        [Fact]
        public void TestCustomerOrders()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_customer_orders")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                string customerId = "some-customer-id";
                Customer customer = new Customer() { CustomerId = customerId };
                bc.Customers.Add(customer);
                bc.Orders.Add(new Order { CustomerId = customerId, OrderId = "some-order-id" });
                bc.Orders.Add(new Order { CustomerId = customerId, OrderId = "some-other-order-id" });
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                List<Order> orders = infoManager.customerOrders(customerId);
                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void TestCustomerOrdersFail()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_customer_orders_fail")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                string customerId = "some-customer-id";
                Customer customer = new Customer() { CustomerId = customerId };
                bc.Customers.Add(customer);
                bc.Orders.Add(new Order { CustomerId = customerId, OrderId = "some-order-id" });
                bc.Orders.Add(new Order { CustomerId = customerId, OrderId = "some-other-order-id" });
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                List<Order> orders = infoManager.customerOrders(customerId);
                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void TestCustomersLike()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_customers_like")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                Customer customerA = new Customer { CustomerId = "some-customer-id", FirstName = "New", LastName = "Customer" };
                Customer customerB = new Customer { CustomerId = "another-customer-id", FirstName = "Another", LastName = "Customer" };
                bc.Customers.Add(customerA);
                bc.Customers.Add(customerB);
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                Customer customer = infoManager.customersLike("New", "Customer");

                Assert.NotNull(customer);
            }
        }

        [Fact]
        public void TestOrderDetails()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_order_details")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                string customerId = "some-customer-id";
                string orderId = "some-order-id";
                Customer customer = new Customer() { CustomerId = customerId, FirstName = "New", LastName = "Customer" };
                OrderItem orderItemA = new OrderItem() { OrderItemId = "some-item-id", OrderId = orderId };
                OrderItem orderItemB = new OrderItem() { OrderItemId = "another-item-id", OrderId = orderId };
                Order order = new Order() { OrderId = orderId, CustomerId = customerId };
                bc.Customers.Add(customer);
                bc.Orders.Add(order);
                bc.OrderItems.Add(orderItemA);
                bc.OrderItems.Add(orderItemB);
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                List<OrderItem> orderItems = infoManager.orderDetails(orderId, customerId);
                Assert.Equal(2, orderItems.Count);
                
            }
        }

        [Fact]
        public void TestOrderDetailsFail()
        {
            var options = new DbContextOptionsBuilder<BusinessContext>()
                .UseInMemoryDatabase(databaseName: "test_order_details_fail")
                .Options;
            using (var bc = new BusinessContext(options))
            {
                string customerId = "some-customer-id";
                string orderId = "some-order-id";
                Order order = new Order() { OrderId = orderId, CustomerId = customerId };
                bc.Orders.Add(order);
                bc.SaveChanges();

                InfoManager infoManager = new InfoManager(bc);
                List<OrderItem> invalid = infoManager.orderDetails("invalid-order-id", "invalid-customer-id");
                List<OrderItem> empty = infoManager.orderDetails(orderId, customerId);
                Assert.Null(invalid);
                Assert.Empty(empty);
            }
        }
    }
}
