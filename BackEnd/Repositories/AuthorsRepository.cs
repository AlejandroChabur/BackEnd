using BackEnd.Context;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public class AuthorsRepository
    {
        private readonly TestDbContext _context;

        public AuthorsRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<List<Authors>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                         .Include(a => a.Person) // Incluir la información de People
                         .Where(a => !a.IsDelete)
                         .ToListAsync();
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
        .Include(a => a.Person) // Cargar la entidad 'People' relacionada
        .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            return author; // Devuelve la insta
        }




        public async Task CreateAuthorAsync(Authors author)
        {
            // Busca la persona existente
            var person = await _context.People.FindAsync(author.IdPerson);

            if (person == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Persona no encontrada");
            }

            // Asigna la persona encontrada al nuevo autor
            author.Person = person;

            // Agrega el nuevo registro de Author
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(Authors author)
        {
            var existingAuthor = await _context.Authors.FindAsync(author.Id);

            if (existingAuthor != null)
            {
                existingAuthor.IdPerson = author.IdPerson;
                existingAuthor.Country = author.Country;
                

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {author.Id} not found.");
            }
        }


        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                author.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}