using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    //public interface IUserRepository
    //{
    //    Task<IEnumerable<User>> GetAllUsersAsync();
    //    Task<User> GetUserByIdAsync(int id);
    //    Task CreateUserAsync(User user);
    //    Task UpdateUserAsync(User user);
    //    Task DeleteUserAsync(int id);
    //}
    public class UserRepository
    {
        private readonly TestDbContext _context;

        public UserRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                
                .Include(a=>a.Peoples)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users

               .Include(a => a.Peoples)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user; // Devolver la instancia del usuario encontrado
        }

        public async Task CreateUserAsync(User user)
        {
            var userType = await _context.UserType
       .FindAsync(user.IdUserType); // Asegúrate de que estás usando el ID correcto

            if (userType == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Tipo de usuario no encontrado");
            }

            // Asigna el tipo de usuario encontrado al nuevo registro de User
            user.UserTypes = userType;

            // Busca la persona existente a la que se asignará el usuario
            var person = await _context.People.FindAsync(user.IdPerson); // Asegúrate de que estás usando el ID correcto

            if (person == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Persona no encontrada");
            }

            // Asigna la persona encontrada al nuevo registro de User
            user.Peoples = person;

            // Ahora agrega el nuevo registro de User
            _context.Users.Add(user);
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
                existingUser.IdPerson = user.IdPerson;
                existingUser.IdUserType = user.IdUserType;

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
