using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    //public interface IPeopleRepository
    //{
        
    //    Task<People> GetPeopleByIdAsync(int id);
    //    Task<IEnumerable<People>> GetAllPeopleAsync();
    //    Task CreatePeopleAsync(People people);
    //    Task UpdatePeopleAsync(People people);
    //    Task DeletePeopleAsync(int id);
    //}
    public class PeopleRepository 
    {
        private readonly TestDbContext _context;

        public PeopleRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _context.People
                .Include(a=> a.IdentificationTypes)
                .ToListAsync();
        }

        public async Task<People> GetPeopleByIdAsync(int id)
        {
            var person = await _context.People
                .Include(a => a.IdentificationTypes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with ID {id} not found.");
            }

            return person; // Devolver la instancia de la persona encontrada
        }

        public async Task CreatePeopleAsync(People people)
        { // Busca el tipo de identificación existente
            var identificationType = await _context.IdentificationTypes
                .FindAsync(people.IdIdentificationType); // Asegúrate de que estás usando el ID correcto

            if (identificationType == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Tipo de identificación no encontrado");
            }

            // Asigna el tipo de identificación encontrado al nuevo registro de People
            people.IdentificationTypes = identificationType;

            // Ahora agrega el nuevo registro de People
            _context.People.Add(people);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePeopleAsync(People people)
        {
            var existingPerson = await _context.People.FindAsync(people.Id);

            if (existingPerson != null)
            {
                // Solo actualiza las propiedades necesarias
                existingPerson.IdIdentificationType = people.IdIdentificationType;
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
