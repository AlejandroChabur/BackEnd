using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType UserType);
        Task UpdateUserTypeAsync(UserType UserType);
        Task DeleteUserTypeAsync(int id);
    }

    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly TestDbContext _context;

        public UserTypeRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            // Suponiendo que IsDeleted es un campo que determina si el tipo de usuario está eliminado
            return await _context.UserType
                
                .ToListAsync();
        }

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            var UserType = await _context.UserType.FindAsync(id);

            if (UserType == null)
            {
                throw new KeyNotFoundException($"UserType with ID {id} not found.");
            }

            return UserType; // Devolver la instancia del tipo de usuario encontrado
        }

        public async Task CreateUserTypeAsync(UserType userType)
        {
            await _context.UserType.AddAsync(userType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserTypeAsync(UserType UserType)
        {
            var existingUserType = await _context.UserType.FindAsync(UserType.Id);

            if (existingUserType != null)
            {
                existingUserType.Name = UserType.Name;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"UserType with ID {UserType.Id} not found.");
            }
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            var userType = await _context.UserType.FindAsync(id);
            if (userType != null)
            {
                userType.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"UserType with ID {id} not found.");
            }
        }
    }
}
