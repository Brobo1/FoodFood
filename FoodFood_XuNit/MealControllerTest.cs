using FoodFood.Controller;
using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFood_XuNit
{
    public class MealControllerTest
    {
        [Fact]
        public async Task GetMealById_WhenMealExists_ReturnsMeal()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetMealById_WhenMealExists_ReturnsMea")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Meal.Add(new Meal { Id = 1, Name = "Burger", Price = 100 });
                context.Meal.Add(new Meal { Id = 2, Name = "Pizza", Price = 200 });
                context.SaveChanges();

                var controller = new MealController(context);

                var result = await controller.GetMeal(1) as OkObjectResult;
                var result2 = await controller.GetMeal(2) as OkObjectResult;

                Assert.NotNull(result);
                var meal = result.Value as Meal;
                Assert.Equal(100, meal?.Price);
                Assert.NotNull(result2);
                var meal2 = result2.Value as Meal;
                Assert.Equal(200, meal2?.Price);
            }
        }
        [Fact]
        public async Task GetMealById_WhenMealDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetMealById_WhenMealDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealController(context);

                var result = await controller.GetMeal(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetMeals_WhenMealsExist_ReturnsMeals()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetMeals_WhenMealsExist_ReturnsMeals")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Meal.Add(new Meal { Id = 1, Name = "Burger", Price = 100 });
                context.Meal.Add(new Meal { Id = 2, Name = "Pizza", Price = 200 });
                context.SaveChanges();

                var controller = new MealController(context);

                var result = await controller.GetMeals() as OkObjectResult;

                Assert.NotNull(result);
                var meals = result.Value as List<Meal>;
                Assert.Equal(2, meals?.Count);
            }
        }
        [Fact]
        public async Task CreateMeal_WhenMealIsCreated_ReturnsCreatedMeal()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreateMeal_WhenMealIsCreated_ReturnsCreatedMeal")
                .Options;
            using (var context = new FoodFoodContext(options))
            { 
                CreateMeal meal= new CreateMeal { Name = "Burger", Price = 100, Allergens = "None", Category = "Fast Food", Description = "A delicious burger", MealImage = "burger.jpg", RestaurantId = 1 };
                var controller = new MealController(context);
                var result= await controller.CreateMeal(meal) as CreatedAtRouteResult;

                Assert.NotNull(result);
                Assert.Equal(201, result.StatusCode);
                var meal1 = result.Value as Meal;
                Assert.Equal("Burger", meal1?.Name);
                Assert.Equal(100, meal1?.Price);
            }
        }
        [Fact]
        public async Task UpdateMeal_WhenMealExists_ReturnsUpdatedMeal()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateMeal_WhenMealExists_ReturnsUpdatedMeal")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Meal.Add(new Meal { Id = 1, Name = "Burger", Price = 100, Allergens = "None", Category = "Fast Food", Description = "A delicious burger", MealImage = "burger.jpg", RestaurantId = 1 });
                context.SaveChanges();

                var controller = new MealController(context);

                var result = await controller.UpdateMeal(1, new CreateMeal { Name = "Pizza", Price = 200, Allergens = "None", Category = "Fast Food", Description = "A delicious burger", MealImage = "burger.jpg", RestaurantId = 1 }) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
                var meal = await context.Meal.FindAsync(1);
                Assert.Equal("Pizza", meal?.Name);
            }
        }
        [Fact]
        public async Task UpdateMeal_WhenMealDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateMeal_WhenMealDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealController(context);

                var result = await controller.UpdateMeal(1, new CreateMeal { Name = "Pizza", Price = 200 }) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task UpdateMeal_WhenMealIsUpdated_ReturnsNoContent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdateMeal_WhenMealIsUpdated_ReturnsNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Meal.Add(new Meal { Id = 1, Name = "Burger", Price = 100 });
                context.SaveChanges();

                var controller = new MealController(context);

                var result = await controller.UpdateMeal(1, new CreateMeal { Name = "Pizza", Price = 200 }) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteMeal_DeletesAMeal()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteMeal_DeletesAMeal")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Meal.Add(new Meal { Id = 1, Name = "Burger", Price = 100 });
                context.SaveChanges();

                var controller = new MealController(context);

                var result = await controller.DeleteMeal(1) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
                var meal = await context.Meal.FindAsync(1);
                Assert.Null(meal);
            }
        }
        [Fact]
        public async Task DeleteMeal_WhenMealDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteMeal_WhenMealDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new MealController(context);

                var result = await controller.DeleteMeal(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
    }
}
