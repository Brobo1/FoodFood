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
    public class PersonaliaControllerTest
    {
        [Fact]
        public async Task GetPersonaliaById_WhenPersonaliaExists_ReturnsPersonalia()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetPersonaliaById_WhenPersonaliaExists_ReturnsPersonalia")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Personalia.Add(new Personalia { Id = 1, FirstName = "Test", LastName = "One", Address = "Brightsvei 12", Birthday = DateTime.Now, UserId = 1 });
                context.Personalia.Add(new Personalia { Id = 2, FirstName = "Test", LastName = "Two", Address = "Brightsvei 13", Birthday = DateTime.Now, UserId = 2 });

                context.SaveChanges();

                var controller = new PersonaliaController(context);

                var result = await controller.Get(1) as OkObjectResult;
                var result2 = await controller.Get(2) as OkObjectResult;

                Assert.NotNull(result);
                var personalia = result.Value as Personalia;
                Assert.Equal("Test", personalia?.FirstName);
                Assert.True(personalia?.Id == 1);
                Assert.Equal("One", personalia?.LastName);
                var personalia2 = result2.Value as Personalia;
                Assert.Equal("Test", personalia2?.FirstName);
                Assert.True(personalia2?.Id == 2);
                Assert.Equal("Two", personalia2?.LastName);
            }
        }
        [Fact]
        public async Task GetPersonaliaById_WhenPersonaliaDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetPersonaliaById_WhenPersonaliaDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PersonaliaController(context);

                var result = await controller.Get(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetAllPersonalia_WhenPersonaliaExist_ReturnsPersonaliaList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetAllPersonalia_WhenPersonaliaExist_ReturnsPersonaliaList")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Personalia.Add(new Personalia { Id = 1, FirstName = "Test", LastName = "One", Address = "Brightsvei 12", Birthday = DateTime.Now, UserId = 1 });
                context.Personalia.Add(new Personalia { Id = 2, FirstName = "Test", LastName = "Two", Address = "Brightsvei 13", Birthday = DateTime.Now, UserId = 2 });

                context.SaveChanges();

                var controller = new PersonaliaController(context);

                var result = await controller.GetAll() as OkObjectResult;

                Assert.NotNull(result);
                var personalia = result.Value as List<Personalia>;
                Assert.Equal(2, personalia?.Count);
            }
        }
        [Fact]
        public async Task CreatePersonalia_ReturnsPersonalia()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreatePersonalia_ReturnsPersonalia")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PersonaliaController(context);

                var personalia = new PersonaliaModel { FirstName = "Test", LastName = "One", Address = "Brightsvei 12", Birthday = DateTime.Now, UserId = 1 };

                var result = await controller.Create(personalia) as OkObjectResult;

                Assert.NotNull(result);
                var personaliaResult = result.Value as Personalia;
                Assert.Equal("Test", personaliaResult?.FirstName);
                Assert.True(personaliaResult?.Id == 1);
                Assert.Equal("One", personaliaResult?.LastName);
            }
        }
        [Fact]
        public async Task UpdatePersonalia_ReturnsPersonalia()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdatePersonalia_ReturnsPersonalia")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Personalia.Add(new Personalia { Id = 1, FirstName = "Test", LastName = "One", Address = "Brightsvei 12", Birthday = DateTime.Now, UserId = 1 });
                context.SaveChanges();

                var controller = new PersonaliaController(context);

                var personalia = new PersonaliaModel { FirstName = "Test", LastName = "Two", Address = "Brightsvei 13", Birthday = DateTime.Now, UserId = 2 };

                var result = await controller.Put(personalia, 1) as OkObjectResult;

                Assert.NotNull(result);
                var personaliaResult = result.Value as Personalia;
                Assert.Equal("Test", personaliaResult?.FirstName);
                Assert.True(personaliaResult?.Id == 1);
                Assert.Equal("Two", personaliaResult?.LastName);
            }
        }
        [Fact]
        public async Task UpdatePersonalia_WhenPersonaliaDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdatePersonalia_WhenPersonaliaDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PersonaliaController(context);

                var personalia = new PersonaliaModel { FirstName = "Test", LastName = "Two", Address = "Brightsvei 13", Birthday = DateTime.Now, UserId = 2 };

                var result = await controller.Put(personalia, 1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeletePersonalia_ReturnsNoContent()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeletePersonalia_ReturnsNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Personalia.Add(new Personalia { Id = 1, FirstName = "Test", LastName = "One", Address = "Brightsvei 12", Birthday = DateTime.Now, UserId = 1 });
                context.SaveChanges();

                var controller = new PersonaliaController(context);

                var result = await controller.Delete(1) as NoContentResult;

                Assert.Equal(204, result?.StatusCode);
            }
        }
        [Fact]
        public async Task DeletePersonalia_WhenPersonaliaDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeletePersonalia_WhenPersonaliaDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PersonaliaController(context);

                var result = await controller.Delete(1) as NotFoundResult;

                Assert.Equal(404, result?.StatusCode);
            }
        }
    }
}
