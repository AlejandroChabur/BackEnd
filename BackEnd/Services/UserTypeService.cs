using BackEnd.Model;
using BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType userType);
        Task UpdateUserTypeAsync(UserType userType);
        Task DeleteUserTypeAsync(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return await _userTypeRepository.GetAllUserTypesAsync();
        }

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _userTypeRepository.GetUserTypeByIdAsync(id);
        }

        public async Task CreateUserTypeAsync(UserType userType)
        {
            await _userTypeRepository.CreateUserTypeAsync(userType);
        }

        public async Task UpdateUserTypeAsync(UserType userType)
        {
            await _userTypeRepository.UpdateUserTypeAsync(userType);
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            await _userTypeRepository.DeleteUserTypeAsync(id);
        }
    }
}
