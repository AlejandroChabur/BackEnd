using BackEnd.Model;
using BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BackEnd.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Obtener todos los usuarios
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Obtener un usuario por su ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // Crear un nuevo usuario
        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
            
        }

        // Actualizar un usuario existente
        public async Task UpdateUserAsync(User user)
        {
            
            await _userRepository.UpdateUserAsync(user);
        }

        // Eliminar un usuario
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        // Iniciar sesión (Login)
        public async Task<User> LoginAsync(string email, string password)
        {
            // Buscar el usuario por correo electrónico
            var user = await _userRepository.GetUserByEmailAsync(email);

            // Verificar si el usuario existe y no está eliminado
            if (user == null || user.IsDelete)
            {
                return null;
            }

            // Comparar las contraseñas usando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null; // Si las contraseñas no coinciden, retornar nulo
            }

            return user; // Retornar el usuario si las credenciales son correctas
        }
    }
}
