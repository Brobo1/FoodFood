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
    public class PaymentControllerTest
    {
        [Fact]
        public async Task GetPaymentById_WhenPaymentExists_ReturnsPayment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetPaymentById_WhenPaymentExists_ReturnsPayment")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Payment.Add(new Payment { Id = 1, CardHolderName = "John Doe", CardNumber = "1234567890", ExpirationDate = DateTime.Now, Type = "Visa" });
                context.Payment.Add(new Payment { Id = 2, CardHolderName = "Jane Doe", CardNumber = "0987654321", ExpirationDate = DateTime.Now, Type = "MasterCard" });
                context.SaveChanges();

                var controller = new PaymentController(context);

                var result = await controller.Get(1) as OkObjectResult;
                var result2 = await controller.Get(2) as OkObjectResult;

                Assert.NotNull(result);
                var payment = result.Value as Payment;
                Assert.Equal("Visa", payment?.Type);
                Assert.NotNull(result2);
                var payment2 = result2.Value as Payment;
                Assert.Equal("MasterCard", payment2?.Type);
            }
        }
        [Fact]
        public async Task GetPaymentById_WhenPaymentDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetPaymentById_WhenPaymentDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PaymentController(context);

                var result = await controller.Get(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task GetPayments_WhenPaymentsExist_ReturnsPayments()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "GetPayments_WhenPaymentsExist_ReturnsPayments")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Payment.Add(new Payment { Id = 1, CardHolderName = "John Doe", CardNumber = "1234567890", ExpirationDate = DateTime.Now, Type = "Visa" });
                context.Payment.Add(new Payment { Id = 2, CardHolderName = "Jane Doe", CardNumber = "0987654321", ExpirationDate = DateTime.Now, Type = "MasterCard" });
                context.SaveChanges();

                var controller = new PaymentController(context);

                var result = await controller.GetAll() as OkObjectResult;

                Assert.NotNull(result);
                var payments = result.Value as List<Payment>;
                Assert.Equal(2, payments?.Count);
            }
        }
        [Fact]
        public async Task CreatePayment_WhenPaymentDataIsValid_ReturnsCreatedPayment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "CreatePayment_WhenPaymentDataIsValid_ReturnsCreatedPayment")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                PaymentModel payment = new PaymentModel
                {
                    CardHolderName = "John Doe",
                    CardNumber = "1234567890",
                    ExpirationDate = DateTime.Now,
                    Type = "Visa"
                };
                var controller = new PaymentController(context);

                var result = await controller.Create(payment) as OkObjectResult;
                Assert.NotNull(result);
                Assert.Equal(200, result.StatusCode);
                var paymentResult = result.Value as Payment;
                Assert.NotNull(paymentResult);
                Assert.Equal("Visa", paymentResult.Type);

            }
        }



        [Fact]
        public async Task UpdatePayment_WhenPaymentExists_ReturnsUpdatedPayment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdatePayment_WhenPaymentExists_ReturnsUpdatedPayment")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Payment.Add(new Payment { Id = 1, CardHolderName = "John Doe", CardNumber = "1234567890", ExpirationDate = DateTime.Now, Type = "Visa" });
                context.SaveChanges();

                var controller = new PaymentController(context);

                var result = await controller.Update(1, new PaymentModel { CardHolderName = "Jane Doe", CardNumber = "0987654321", ExpirationDate = DateTime.Now, Type = "MasterCard" }) as OkObjectResult;

                Assert.NotNull(result);
                var payment = result.Value as Payment;
                Assert.Equal("MasterCard", payment?.Type);
            }
        }
        [Fact]
        public async Task UpdatePayment_WhenPaymentDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "UpdatePayment_WhenPaymentDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PaymentController(context);

                var result = await controller.Update(1, new PaymentModel { CardHolderName = "Jane Doe", CardNumber = "0987654321", ExpirationDate = DateTime.Now, Type = "MasterCard" }) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeletePayment_ReturnsNoContent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeletePayment_ReturnsNoContent")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                context.Payment.Add(new Payment { Id = 1, CardHolderName = "John Doe", CardNumber = "1234567890", ExpirationDate = DateTime.Now, Type = "Visa" });
                context.SaveChanges();

                var controller = new PaymentController(context);

                var result = await controller.Delete(1) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
        }
        [Fact]
        public async Task DeletePayment_WhenPaymentDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FoodFoodContext>()
                .UseInMemoryDatabase(databaseName: "DeletePayment_WhenPaymentDoesNotExist_ReturnsNotFound")
                .Options;
            using (var context = new FoodFoodContext(options))
            {
                var controller = new PaymentController(context);

                var result = await controller.Delete(1) as NotFoundResult;

                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode);
            }
        }
    }
}

