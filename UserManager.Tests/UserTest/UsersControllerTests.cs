// Tests/UsersControllerTests.cs
using Xunit;
using System.Threading.Tasks;
using Moq;
using MediatR;
using UserManager.Application.Commands;
using UserManager.Domain.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using UserManager.API.Controllers;

namespace UserManager.Tests
{
	public class UsersControllerTests
	{
		[Fact]
		public async Task CreateUser_ReturnsCreatedAtActionResult_WithUserId()
		{
			// Arrange
			var mediatorMock = new Mock<IMediator>();
			mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), default))
						.ReturnsAsync(1); // Assuming the user ID is 1

			var controller = new UsersController(mediatorMock.Object);

			var command = new CreateUserCommand
			{
				FirstName = "John",
				LastName = "Doe",
				Email = "john.doe@example.com",
				Password = "password123",
				SubscriptionType = SubscriptionType.Premium,
				SubscriptionStartDate = DateTime.UtcNow,
				SubscriptionEndDate = DateTime.UtcNow.AddYears(1),
				Role = UserRole.User
			};

			// Act
			var result = await controller.Create(command);

			// Assert
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
			Assert.Equal(1, createdAtActionResult.Value);
		}
	}
}
