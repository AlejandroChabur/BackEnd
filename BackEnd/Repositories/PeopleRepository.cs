using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task<People> GetPeopleByIdAsync(int id);
        Task CreatePeopleAsync(People people);
        Task UpdatePeopleAsync(People people);
        Task DeletePeopleAsync(int id);
    }
    public class PeopleRepository : IPeopleRepository
    {
        private readonly TestDbContext _context;

        public PeopleRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _context.People
          
                .ToListAsync();
        }

        public async Task<People> GetPeopleByIdAsync(int id)
        {
            var person = await _context.People
                .Include(p => p.IdentificationType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with ID {id} not found.");
            }

            return person; // Devolver la instancia de la persona encontrada
        }

        public async Task CreatePeopleAsync(People people)
        {
            await _context.People.AddAsync(people);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePeopleAsync(People people)
        {
            var existingPerson = await _context.People.FindAsync(people.Id);

            if (existingPerson != null)
            {
                // Solo actualiza las propiedades necesarias
                existingPerson.IdentificationType = people.IdentificationType;
                existingPerson.IdentificationNumber = people.IdentificationNumber;
                existingPerson.FirstName = people.FirstName;
                existingPerson.MiddleName = people.MiddleName;
                existingPerson.LastName = people.LastName;
                existingPerson.SecondLastName = people.SecondLastName;
                existingPerson.Address = people.Address;
                existingPerson.borndate = people.borndate;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Person with ID {people.Id} not found.");
            }
        }

        public async Task DeletePeopleAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        
    }
}
}
