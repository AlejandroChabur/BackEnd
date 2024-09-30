using BackEnd.Model;
using BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task<People> GetPeopleByIdAsync(int id);
        Task CreatePeopleAsync(People people);
        Task UpdatePeopleAsync(People people);
        Task DeletePeopleAsync(int id);
    }

    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _peopleRepository.GetAllPeopleAsync();
        }

        public async Task<People> GetPeopleByIdAsync(int id)
        {
            return await _peopleRepository.GetPeopleByIdAsync(id);
        }

        public async Task CreatePeopleAsync(People people)
        {
            await _peopleRepository.CreatePeopleAsync(people);
        }

        public async Task UpdatePeopleAsync(People people)
        {
            await _peopleRepository.UpdatePeopleAsync(people);
        }

        public async Task DeletePeopleAsync(int id)
        {
            await _peopleRepository.DeletePeopleAsync(id);
        }
    }
}
