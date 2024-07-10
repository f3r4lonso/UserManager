using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Interfaces;

namespace UserManager.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
	private readonly ApplicationDbContext _context;

	public UserRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<User?> GetByIdAsync(Guid id)
	{
		return await _context.Users.FindAsync(id);
	}

	public async Task<User> CreateAsync(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
		return user;
	}

	public async Task UpdateAsync(User user)
	{
		_context.Entry(user).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user != null)
		{
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}
	}
}