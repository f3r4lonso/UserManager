using MediatR;
using UserManager.Domain.Entities.Enums;

namespace UserManager.Application.Commands
{
	public class CreateUserCommand : IRequest<int>
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public SubscriptionType SubscriptionType { get; set; }
		public DateTime SubscriptionStartDate { get; set; }
		public DateTime SubscriptionEndDate { get; set; }
		public UserRole Role { get; set; }
	}
}
