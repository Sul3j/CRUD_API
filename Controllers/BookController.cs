using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public BookController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Book>> GetAll() =>
            BookService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookService.Get(id);

            if (book == null)
                return NotFound();

            return book;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Book book)
        {
            BookService.Add(book);
            return CreatedAtAction(nameof(Create), new { id = book.Id }, book);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            var existingBook = BookService.Get(id);
            if (existingBook is null)
                return NotFound();

            BookService.Update(book);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookService.Get(id);

            if (book is null)
                return NotFound();

            BookService.Delete(id);

            return NoContent();
        }
    }
}
