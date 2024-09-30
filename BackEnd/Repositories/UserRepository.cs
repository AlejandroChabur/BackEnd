using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly TestDbContext _context;

        public UserRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Where(s => s.IsDeleted)
                .Include(u => u.UserType) // Incluye UserType si es necesario
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Where(s => s.IsDeleted)
                .Include(u => u.UserType) // Incluye UserType si es necesario
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user; // Devolver la instancia del usuario encontrado
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.IdPersona = user.IdPersona;
                existingUser.UserType = user.UserType;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
