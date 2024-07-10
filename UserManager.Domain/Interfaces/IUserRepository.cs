using System;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces;

public interface IUserRepository
{
	Task<User?> GetByIdAsync(Guid id);
	Task<User> CreateAsync(User user);
	Task UpdateAsync(User user);
	Task DeleteAsync(Guid id);
}