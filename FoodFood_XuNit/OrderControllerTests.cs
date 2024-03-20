using FoodFood.Data.Models;
using FoodFood.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFood.Controller;
using Microsoft.AspNetCore.Mvc;
using FoodFood.Controller.ControllerModels;

namespace FoodFood_XuNit
{
    public class OrderControllerTests
    {
        [Fact]
        public async Task GetOrderById_WhenOrderExists_ReturnsOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetOrderById_WhenOrderExists_ReturnsOrder")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Order.Add(new Order { Id = 1, OrderDate = DateTime.Now, IsDelivered = false, TotalPrice = 100 });
                context.Order.Add(new Order { Id = 2, OrderDate = DateTime.Now, IsDelivered = false, TotalPrice = 200 });
                context.SaveChanges();

                var controller = new OrderController(context);

                var result = await controller.GetOrder(1) as OkObjectResult;
                var result2 = await controller.GetOrder(2) as OkObjectResult;

                Assert.NotNull(result);
                var order = result.Value as Order;
                Assert.Equal(100, order?.TotalPrice);
                Assert.NotNull(result2);
                var order2 = result2.Value as Order;
                Assert.Equal(200, order2?.TotalPrice);
            }
        }

        [Fact]
        public async Task GetOrderById_WhenOrderDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetOrderById_WhenOrderDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new OrderController(context);

                var result = await controller.GetOrder(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }

        [Fact]
        public async Task GetOrders_ReturnsAListOfOrders()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetOrders_ReturnsAListOfOrders")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Order.Add(new Order { Id = 1, OrderDate = DateTime.Now, IsDelivered = false, TotalPrice = 100 });
                context.Order.Add(new Order { Id = 2, OrderDate = DateTime.Now, IsDelivered = false, TotalPrice = 200 });
                context.SaveChanges();

                var controller = new OrderController(context);

                var result = await controller.GetOrders() as OkObjectResult;

                Assert.NotNull(result);
                var orders = result.Value as List<Order>;
                Assert.Equal(2, orders?.Count);
            }
        }
        [Fact]
        public async Task CreateOrder_CreatesAnOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreateOrder_CreatesAnOrder")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                CreateOrder order = new CreateOrder
                {
                    OrderDate = DateTime.Now,
                    IsDelivered = false,
                    TotalPrice = 100
                };

                var controller = new OrderController(context);

                var result = await controller.CreateOrder(order) as CreatedAtActionResult;

                Assert.NotNull(result);
                Assert.Equal(201, result.StatusCode);
                Assert.Equal("GetOrder", result.ActionName);
                Assert.Equal(1, result.RouteValues?["id"]);
            }
        }
        [Fact]
        public async Task UpdateOrder_UpdatesAnOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateOrder_UpdatesAnOrder")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Order.Add(new Order { Id = 1, OrderDate = DateTime.Now, IsDelivered = false, TotalPrice = 100 });
                context.SaveChanges();

                var controller = new OrderController(context);

                var result = await controller.UpdateOrder(1, new Order { Id = 1, OrderDate = DateTime.Now, IsDelivered = true, TotalPrice = 200 }) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
                var order = await context.Order.FindAsync(1);
                Assert.True(order?.IsDelivered);
                Assert.Equal(200, order?.TotalPrice);
            }
        }
        [Fact]
        public async Task UpdateOrder_WhenOrderDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateOrder_WhenOrderDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new OrderController(context);

                var result = await controller.UpdateOrder(1, new Order { Id = 1, OrderDate = DateTime.Now, IsDelivered = true, TotalPrice = 200 }) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteOrder_DeletesAnOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteOrder_DeletesAnOrder")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Order.Add(new Order { Id = 1, OrderDate = DateTime.Now, IsDelivered = false, TotalPrice = 100 });
                context.SaveChanges();

                var controller = new OrderController(context);

                var result = await controller.DeleteOrder(1) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
                var order = await context.Order.FindAsync(1);
                Assert.Null(order);
            }
        }
        [Fact]
        public async Task DeleteOrder_WhenOrderDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteOrder_WhenOrderDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new OrderController(context);

                var result = await controller.DeleteOrder(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
    }
}
