using UserManager.Domain.Entities;
using UserManager.Domain.Entities.Enums;

public class User
{
	public int Id { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public int SubscriptionId { get; set; }
	public UserRole Role { get; set; }

	public required Subscription Subscription { get; set; }
}
