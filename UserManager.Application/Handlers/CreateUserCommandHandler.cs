using MediatR;
using UserManager.Domain.Entities;
using UserManager.Application.Commands;
using UserManager.Infrastructure.Persistence;

namespace UserManager.Application.Handlers
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
	{
		private readonly ApplicationDbContext _context;

		public CreateUserCommandHandler(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var subscription = new Subscription
			{
				SubscriptionType = request.SubscriptionType.ToString(),
				StartDate = request.SubscriptionStartDate,
				EndDate = request.SubscriptionEndDate
			};

			var user = new User
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Password = request.Password,
				Subscription = subscription,
				Role = request.Role
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync(cancellationToken);

			return user.Id;
		}
	}
}
