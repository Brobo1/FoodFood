using FoodFood.Controller;
using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFood_XuNit
{
    public class MealOrderControllerTest
    {
        [Fact]
        public async Task GetMealOrderById_WhenMealOrderExists_ReturnsMealOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetMealOrderById_WhenMealOrderExists_ReturnsMealOrder")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.MealOrder.Add(new MealOrder { Id = 1, OrderId = 1, MealId = 1, Quantity = 1 });
                context.MealOrder.Add(new MealOrder { Id = 2, OrderId = 2, MealId = 2, Quantity = 2 });
                context.SaveChanges();

                var controller = new MealOrderController(context);

                var result = await controller.GetMealOrder(1) as OkObjectResult;
                var result2 = await controller.GetMealOrder(2) as OkObjectResult;

                Assert.NotNull(result);
                var mealOrder = result.Value as MealOrder;
                Assert.Equal(1, mealOrder?.OrderId);
                Assert.NotNull(result2);
                var mealOrder2 = result2.Value as MealOrder;
                Assert.Equal(2, mealOrder2?.OrderId);
            }
        }
        [Fact]
        public async Task GetMealOrderById_WhenMealOrderDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetMealOrderById_WhenMealOrderDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealOrderController(context);

                var result = await controller.GetMealOrder(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetMealOrders_WhenMealOrdersExist_ReturnsMealOrders()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetMealOrders_WhenMealOrdersExist_ReturnsMealOrders")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.MealOrder.Add(new MealOrder { Id = 1, OrderId = 1, MealId = 1, Quantity = 1 });
                context.MealOrder.Add(new MealOrder { Id = 2, OrderId = 2, MealId = 2, Quantity = 2 });
                context.SaveChanges();

                var controller = new MealOrderController(context);

                var result = await controller.GetMealOrders() as OkObjectResult;

                Assert.NotNull(result);
                var mealOrders = result.Value as List<MealOrder>;
                Assert.Equal(2, mealOrders?.Count);
            }
        }
        [Fact]
        public async Task CreateMealOrder_WhenMealOrderIsValid_ReturnsCreated()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreateMealOrder_WhenMealOrderIsValid_ReturnsCreated")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealOrderController(context);

                var result = await controller.CreateMealOrder(new CreateMealOrder { OrderId = 1, MealId = 1, Quantity = 1 }) as CreatedAtActionResult;

                Assert.NotNull(result);
                Assert.Equal(201, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteMealOrder_WhenMealOrderExists_ReturnsNoContent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteMealOrder_WhenMealOrderExists_ReturnsNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.MealOrder.Add(new MealOrder { Id = 1, OrderId = 1, MealId = 1, Quantity = 1 });
                context.SaveChanges();

                var controller = new MealOrderController(context);

                var result = await controller.DeleteMealOrder(1) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteMealOrder_WhenMealOrderDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteMealOrder_WhenMealOrderDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealOrderController(context);

                var result = await controller.DeleteMealOrder(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task UpdateMealOrder_WhenMealOrderExists_ReturnsNoContent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateMealOrder_WhenMealOrderExists_ReturnsNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.MealOrder.Add(new MealOrder { Id = 1, OrderId = 1, MealId = 1, Quantity = 1 });
                context.SaveChanges();

                var controller = new MealOrderController(context);

                var result = await controller.UpdateMealOrder(1, new CreateMealOrder { OrderId = 1, MealId = 1, Quantity = 2 }) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
        }
        [Fact]
        public async Task UpdateMealOrder_WhenMealOrderDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateMealOrder_WhenMealOrderDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealOrderController(context);

                var result = await controller.UpdateMealOrder(1, new CreateMealOrder { OrderId = 1, MealId = 1, Quantity = 1 }) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }

    }
}
