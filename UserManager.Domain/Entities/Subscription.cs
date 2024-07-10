namespace UserManager.Domain.Entities
{
	public class Subscription
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public required string SubscriptionType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
