using System.Collections.Generic; // Add this using directive
using System.Linq;
using Xunit;
using FoodFood.Controller;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FoodFood.Controller.ControllerModels;

namespace FoodFood_XuNit
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUsers_ReturnsAListOfUsers()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetUsers_ReturnsAListOfUsers")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.User.Add(new User { Id = 1, UserName = "test@gmail.com" });
                context.User.Add(new User { Id = 2, UserName = "test2@gmail.com" });
                context.SaveChanges();

                var controller = new UserController(context);

                // Act
                var result = await controller.GetUsers() as OkObjectResult;

                // Assert
                Assert.NotNull(result);
                var users = result.Value as List<User>;
                Assert.Equal(2, users?.Count);
            }
        }
        [Fact]
        public async Task GetUser_ReturnsAUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetUser_ReturnsAUser")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.User.Add(new User { Id = 1, UserName = "test@gmail.com" });

                var controller = new UserController(context);

                var result = await controller.GetUser(1) as OkObjectResult;

                Assert.NotNull(result);
                var user = result.Value as User;
                Assert.Equal("test@gmail.com", user?.UserName);

            }
        }
        [Fact]
        public async Task CreateUser_CreatesAUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreateUser_CreatesAUser")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                CreateUser user = new CreateUser
                {
                    UserName = "test@gmai.com",
                    Password = "password"
                };

                var controller = new UserController(context);

                var result = await controller.CreateUser(user) as CreatedAtActionResult;

                Assert.NotNull(result);
                Assert.Equal("GetUser", result.ActionName);
                Assert.Equal(1, result.RouteValues?["id"]);

            }
        }

        [Fact]
        public async Task DeleteUser_DeletesAUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteUser_DeletesAUser")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.User.Add(new User { Id = 1, UserName = "test@gmail.com" });
                var controller = new UserController(context);

                var result = await controller.DeleteUser(1) as NoContentResult;

                Assert.Empty(context.User);
                Assert.True(context.User.All(u => u.Id != 1));
                Assert.Equal(204, result?.StatusCode);

            }
        }

        [Fact]
        public async Task DeleteUser_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteUser_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new UserController(context);

                var result = await controller.DeleteUser(1) as NotFoundResult;

                Assert.Equal(404, result?.StatusCode);

            }
        }
        [Fact]
        public async Task UpdatesUser_ReturnUpdatedUser()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdatesUser_ReturnUpdatedUser")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.User.Add(new User { Id = 1, UserName = "test@gmail.com" });
                var controller = new UserController(context);

                var result = await controller.UpdateUser(1, new CreateUser { UserName = "newTest@gmail.com", Password = "password" }) as NoContentResult;

                var user = context.User.Find(1);
                Assert.Equal("newTest@gmail.com", user?.UserName);
                Assert.Equal(204, result?.StatusCode);
            }
        }
        [Fact]
        public async Task UpdatesUser_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdatesUser_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new UserController(context);

                var result = await controller.UpdateUser(1, new CreateUser { UserName = "test@gmail.com", Password = "password" }) as NotFoundResult;

                Assert.Equal(404, result?.StatusCode);
            }
        }
        [Fact]
        public async Task GetUser_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetUser_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new UserController(context);

                var result = await controller.GetUser(1) as NotFoundResult;

                Assert.Equal(404, result?.StatusCode);
            }
        }
    }
}
