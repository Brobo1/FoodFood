using FoodFood.Controller;
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
    public class RestaurantRatingController
    {
        [Fact]
        public async Task GetRestaurantRatingById_WhenRestaurantRatingExists_ReturnsRestaurantRating()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurantRatingById_WhenRestaurantRatingExists_ReturnsRestaurantRating")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.RestaurantRatings.Add(new RestaurantRating { Id = 1, RatingId = 1, RestaurantId = 1, Rating = new Rating { Id = 1, Stars= 5 } });
                context.RestaurantRatings.Add(new RestaurantRating { Id = 2, RatingId = 2, RestaurantId = 2, Rating = new Rating { Id = 2, Stars = 4 } });
                context.SaveChanges();

                var controller = new ResturantRatingController(context);

                var result = await controller.Get(1) as OkObjectResult;
                var result2 = await controller.Get(2) as OkObjectResult;

                Assert.NotNull(result);
                var restaurantRating = result.Value as RestaurantRating;
                Assert.Equal(5, restaurantRating?.Rating?.Stars);
                Assert.NotNull(result2);
                var restaurantRating2 = result2.Value as RestaurantRating;
                Assert.Equal(4, restaurantRating2?.Rating?.Stars);
            }
        }
        [Fact]

        public async Task GetRestaurantRatingById_WhenRestaurantRatingDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurantRatingById_WhenRestaurantRatingDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new ResturantRatingController(context);

                var result = await controller.Get(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetRestaurantRatings_WhenRestaurantRatingsExist_ReturnsRestaurantRatings()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetRestaurantRatings_WhenRestaurantRatingsExist_ReturnsRestaurantRatings")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.RestaurantRatings.Add(new RestaurantRating { Id = 1, RatingId = 1, RestaurantId = 1, Rating = new Rating { Id = 1, Stars = 5 } });
                context.RestaurantRatings.Add(new RestaurantRating { Id = 2, RatingId = 2, RestaurantId = 2, Rating = new Rating { Id = 2, Stars = 4 } });
                context.SaveChanges();

                var controller = new ResturantRatingController(context);

                var result = await controller.GetAll() as OkObjectResult;

                Assert.NotNull(result);
                var restaurantRatings = result.Value as List<RestaurantRating>;
                Assert.Equal(2, restaurantRatings?.Count);
            }
        }

    }
}
