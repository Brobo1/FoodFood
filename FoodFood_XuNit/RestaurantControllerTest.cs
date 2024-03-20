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
    public class RestaurantControllerTest
    {
        [Fact]
        public async Task GetRestaurantById_WhenRestaurantExists_ReturnsRestaurant()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurantById_WhenRestaurantExists_ReturnsRestaurant")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Restaurants.Add(new Restaurant { Id = 1, Name = "McDonalds", Address = "Street 1", Category = "Fast Food", Description = "McDonalds is a fast food restaurant chain", Image = "mcdonalds.jpg" });
                context.Restaurants.Add(new Restaurant { Id = 2, Name = "Burger King", Address = "Street 2", Category = "Fast Food", Description = "Burger King is a fast food restaurant chain", Image = "burgerking.jpg" });
                context.SaveChanges();

                var controller = new RestaurantController(context);

                var result = await controller.GetRestaurant(1) as OkObjectResult;
                var result2 = await controller.GetRestaurant(2) as OkObjectResult;

                Assert.NotNull(result);
                var restaurant = result.Value as Restaurant;
                Assert.Equal("McDonalds", restaurant?.Name);
                Assert.NotNull(result2);
                var restaurant2 = result2.Value as Restaurant;
                Assert.Equal("Burger King", restaurant2?.Name);
            }
        }
        [Fact]
        public async Task GetRestaurantById_WhenRestaurantDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurantById_WhenRestaurantDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RestaurantController(context);

                var result = await controller.GetRestaurant(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetRestaurants_WhenRestaurantsExist_ReturnsRestaurants()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurants_WhenRestaurantsExist_ReturnsRestaurants")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Restaurants.Add(new Restaurant { Id = 1, Name = "McDonalds", Address = "Street 1", Category = "Fast Food", Description = "McDonalds is a fast food restaurant chain", Image = "mcdonalds.jpg" });
                context.Restaurants.Add(new Restaurant { Id = 2, Name = "Burger King", Address = "Street 2", Category = "Fast Food", Description = "Burger King is a fast food restaurant chain", Image = "burgerking.jpg" });
                context.SaveChanges();

                var controller = new RestaurantController(context);

                var result = await controller.GetRestaurants() as OkObjectResult;
                Assert.NotNull(result);
                var restaurants = result.Value as List<Restaurant>;
                Assert.Equal(2, restaurants?.Count);

            }
        }
        [Fact]
        public async Task CreateRestaurant_WhenRestaurantIsCreated_ReturnsCreatedRestaurant()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreateRestaurant_WhenRestaurantIsCreated_ReturnsCreatedRestaurant")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                CreateRestaurant restaurant = new CreateRestaurant { Name = "McDonalds", Address = "Street 1", Category = "Fast Food", Description = "McDonalds is a fast food restaurant chain", Image = "mcdonalds.jpg" };
                var controller = new RestaurantController(context);

                var result = await controller.CreateRestaurant(restaurant) as CreatedAtRouteResult;

                Assert.NotNull(result);
                var restaurantResult = result.Value as Restaurant;
                Assert.Equal("McDonalds", restaurantResult?.Name);
                Assert.Equal("Street 1", restaurantResult?.Address);
            }
        }
        
        [Fact]
        public async Task UpdateRestaurant_WhenRestaurantExists_ReturnsUpdatedRestaurant()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateRestaurant_WhenRestaurantExists_ReturnsUpdatedRestaurant")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Restaurants.Add(new Restaurant { Id = 1, Name = "McDonalds", Address = "Street 1", Category = "Fast Food", Description = "McDonalds is a fast food restaurant chain", Image = "mcdonalds.jpg" });
                context.SaveChanges();

                var controller = new RestaurantController(context);

                CreateRestaurant restaurant = new () { Name = "Burger King", Address = "Street 2", Category = "Fast Food", Description = "Burger King is a fast food restaurant chain", Image = "burgerking.jpg" };
                var result = await controller.UpdateRestaurant(1, restaurant) as NoContentResult;
                var restaurantResult= await context.Restaurants.FindAsync(1);

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
                Assert.Equal("Burger King", restaurantResult?.Name);
                Assert.Equal("Street 2", restaurantResult?.Address);


            }
        }
        [Fact]
        public async Task UpdateRestaurant_WhenRestaurantDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateRestaurant_WhenRestaurantDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RestaurantController(context);

                CreateRestaurant restaurant = new () { Name = "Burger King", Address = "Street 2", Category = "Fast Food", Description = "Burger King is a fast food restaurant chain", Image = "burgerking.jpg" };
                var result = await controller.UpdateRestaurant(1, restaurant) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteRestaurant_WhenRestaurantExists_ReturnsNoContent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteRestaurant_WhenRestaurantExists_ReturnsNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Restaurants.Add(new Restaurant { Id = 1, Name = "McDonalds", Address = "Street 1", Category = "Fast Food", Description = "McDonalds is a fast food restaurant chain", Image = "mcdonalds.jpg" });
                context.SaveChanges();

                var controller = new RestaurantController(context);

                var result = await controller.DeleteRestaurant(1) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteRestaurant_WhenRestaurantDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteRestaurant_WhenRestaurantDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RestaurantController(context);

                var result = await controller.DeleteRestaurant(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetRestaurantById_WhenRestaurantExists_ReturnsRestaurant2()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurantById_WhenRestaurantExists_ReturnsRestaurant2")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Restaurants.Add(new Restaurant { Id = 1, Name = "McDonalds", Address = "Street 1", Category = "Fast Food", Description = "McDonalds is a fast food restaurant chain", Image = "mcdonalds.jpg" });
                context.Restaurants.Add(new Restaurant { Id = 2, Name = "Burger King", Address = "Street 2", Category = "Fast Food", Description = "Burger King is a fast food restaurant chain", Image = "burgerking.jpg" });
                context.SaveChanges();

                var controller = new RestaurantController(context);

                var result = await controller.GetRestaurant(2) as OkObjectResult;

                Assert.NotNull(result);
                var restaurant = result.Value as Restaurant;
                Assert.Equal("Burger King", restaurant?.Name);
            }
        }

    }
}
