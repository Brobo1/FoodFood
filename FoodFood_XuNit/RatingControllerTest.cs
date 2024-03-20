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
    public class RatingControllerTest
    {
        [Fact]
        public async Task GetRatingById_WhenRatingExists_ReturnsRating()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatingById_WhenRatingExists_ReturnsRating")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Rating.Add(new Rating { Id = 1, Review = "Good", Stars = 5, UserId = 1 });
                context.Rating.Add(new Rating { Id = 2, Review = "Good", Stars = 4, UserId = 2 });
                context.SaveChanges();

                var controller = new RatingController(context);

                var result = await controller.GetRating(1) as OkObjectResult;
                var result2 = await controller.GetRating(2) as OkObjectResult;

                Assert.NotNull(result);
                var rating = result.Value as Rating;
                Assert.Equal(5, rating?.Stars);
                Assert.NotNull(result2);
                var rating2 = result2.Value as Rating;
                Assert.Equal(4, rating2?.Stars);
            }
        }
        [Fact]
        public async Task GetRatingById_WhenRatingDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatingById_WhenRatingDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RatingController(context);

                var result = await controller.GetRating(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
       
        [Fact]
        public async Task GetRatings_WhenRatingsExist_ReturnsRatings()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatings_WhenRatingsExist_ReturnsRatings")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Rating.Add(new Rating { Id = 1, Review = "Good", Stars = 5, UserId = 1 });
                context.Rating.Add(new Rating { Id = 2, Review = "Good", Stars = 4, UserId = 2 });
                context.SaveChanges();

                var controller = new RatingController(context);

                var result = await controller.GetRatings() as OkObjectResult;
                Assert.NotNull(result);
                var ratings = result.Value as IEnumerable<Rating>;
                Assert.Equal(2, ratings?.Count());
            }
        }
        [Fact]
        public async Task GetRatings_WhenRatingsDoNotExist_ReturnsEmptyList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatings_WhenRatingsDoNotExist_ReturnsEmptyList")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RatingController(context);

                var result = await controller.GetRatings() as OkObjectResult;
                Assert.NotNull(result);
                var ratings = result.Value as IEnumerable<Rating>;
                Assert.Empty(ratings);
            }
        }
        [Fact]
        public async Task CreateRating_WhenRatingDoesNotExist_ReturnsCreatedRating()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreateRating_WhenRatingDoesNotExist_ReturnsCreatedRating")
                .Options;

            using (var context = new FoodFoodContext(options))
            {
                CreateRating rating = new CreateRating { Review = "Good", Stars = 5, UserId = 1, RestaurantId = 1 };
                var controller = new RatingController(context);

                // Act
                var result = await controller.CreateRating(rating) as CreatedAtActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal(201, result.StatusCode);
                Assert.IsType<Rating>(result.Value); 
            }
        }
        [Fact]
        public async Task GetRatingsByRestaurant_WhenRatingsExist_ReturnsRatings()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatingsByRestaurant_WhenRatingsExist_ReturnsRatings")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Rating.Add(new Rating { Id = 1, Review = "Good", Stars = 5, UserId = 1 });
                context.Rating.Add(new Rating { Id = 2, Review = "Good", Stars = 4, UserId = 2 });
                context.RestaurantRatings.Add(new RestaurantRating { RatingId = 1, RestaurantId = 1 });
                context.RestaurantRatings.Add(new RestaurantRating { RatingId = 2, RestaurantId = 2 });
                context.SaveChanges();

                var controller = new RatingController(context);

                var result = await controller.GetRatingsByRestaurant(1) as OkObjectResult;
                Assert.NotNull(result);
                var ratings = result.Value as IEnumerable<Rating>;
                Assert.Single(ratings);
            }
        }
        
        [Fact]
        public async Task GetRatingsByRestaurant_WhenRatingsExist_ReturnsRatingsByRestaurant()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatingsByRestaurant_WhenRatingsExist_ReturnsRatingsByRestaurant")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Rating.Add(new Rating { Id = 1, Review = "Good", Stars = 5, UserId = 1 });
                context.Rating.Add(new Rating { Id = 2, Review = "Good", Stars = 4, UserId = 2 });
                context.RestaurantRatings.Add(new RestaurantRating { RatingId = 1, RestaurantId = 1 });
                context.RestaurantRatings.Add(new RestaurantRating { RatingId = 2, RestaurantId = 2 });
                context.SaveChanges();

                var controller = new RatingController(context);

                var result = await controller.GetRatingsByRestaurant(1) as OkObjectResult;
                Assert.NotNull(result);
                var ratings = result.Value as IEnumerable<Rating>;
                Assert.Single(ratings);
            }
        }
        
        [Fact]
        public async Task GetRatingsByRestaurant_WhenRestaurantDoesNotExist_ReturnsEmptyListByRestaurant()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRatingsByRestaurant_WhenRestaurantDoesNotExist_ReturnsEmptyListByRestaurant")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RatingController(context);

                var result = await controller.GetRatingsByRestaurant(1) as OkObjectResult;
                Assert.NotNull(result);
                var ratings = result.Value as IEnumerable<Rating>;
                Assert.Empty(ratings);
            }
        }
        [Fact]
        public async Task DeleteRating_ReturnNoContent()
        {

            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteRating_ReturnNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Rating.Add(new Rating { Id = 1, Review = "Good", Stars = 5, UserId = 1 });
                context.SaveChanges();

                var controller = new RatingController(context);

                var result = await controller.DeleteRating(1) as NoContentResult;
                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeleteRating_WhenRatingDoesNotExist_ReturnsNotFound()
        {
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeleteRating_WhenRatingDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new RatingController(context);

                var result = await controller.DeleteRating(1) as NotFoundResult;
                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
    }
}
