using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBookById(int id)
        {
            var book = await _booksService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] Books book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _booksService.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Books book)
        {
            if (id != book.Id)
                return BadRequest();

            var existingBook = await _booksService.GetBookByIdAsync(id);
            if (existingBook == null)
                return NotFound();

            await _booksService.UpdateBookAsync(book);
            return NoContent();
        }

        // DELETE: api/books/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteBook(int id)
        {
            var book = await _booksService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            await _booksService.SoftDeleteBookAsync(id);
            return NoContent();
        }
    }
}
