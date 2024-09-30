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
            return await _context.Authors.ToListAsync();
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            return author; // Devuelve la instancia del autor encontrado
        }




        public async Task CreateAuthorAsync(Authors author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(Authors author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
