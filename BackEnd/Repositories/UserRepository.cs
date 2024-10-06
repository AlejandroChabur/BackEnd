using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public class UserRepository
    {
        private readonly TestDbContext _context;

        public UserRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(a => a.Peoples)
                .Include(a => a.UserTypes)
                .Where(a => !a.IsDelete)
                .ToListAsync();

        }

        // Obtener un usuario por su ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(a => a.Peoples)
                .Include(a => a.UserTypes)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        // Crear un nuevo usuario
        public async Task CreateUserAsync(User user)
        {
            var userType = await _context.UserType.FindAsync(user.IdUserType);
            if (userType == null)
            {
                throw new Exception("Tipo de usuario no encontrado");
            }

            // Asignar tipo de usuario
            user.UserTypes = userType;

            // Buscar la persona asociada al usuario
            var person = await _context.People.FindAsync(user.IdPerson);
            if (person == null)
            {
                throw new Exception("Persona no encontrada");
            }
            

            // Asignar la persona encontrada
            user.Peoples = person;

            // Hashear la contraseña antes de guardar el usuario
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // Verificar el hash de la contraseña en la consola
            Console.WriteLine("Password Hash: " + user.Password);

            // Agregar el nuevo registro de usuario
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            
        }


        // Actualizar un usuario existente
        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                // Solo actualizar la contraseña si se proporciona una nueva
                if (!string.IsNullOrEmpty(user.Password))
                {
                    existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                }

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

        // Eliminar un usuario
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }

        // Obtener un usuario por su correo electrónico para el inicio de sesión
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.UserTypes) // Incluir tipo de usuario si es necesario
                .Include(u => u.Peoples)   // Incluir persona si es necesario
                .FirstOrDefaultAsync(s => s.Email == email && !s.IsDelete);

            // Manejo de errores: lanzar excepción si el usuario no se encuentra
            if (user == null)
            {
                throw new KeyNotFoundException($"No se encontró un usuario con el correo: {email}");
            }

            return user;
        }


    }
}
