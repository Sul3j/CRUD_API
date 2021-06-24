using LibraryApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Services
{
    public static class BookService
    {
        static List<Book> Books { get; }
        static int nextId = 3;

        static BookService()
        {
            Books = new List<Book>
            {
                new Book {Id = 1, Name = "Harry Potter", Author = "J.K. Rowling", Prize = 69.99, HardCover = true },
                new Book {Id = 2, Name = "Hobbit", Author = "J.R.R. Tolkien", Prize = 47.99, HardCover = false },
                new Book {Id = 3, Name = "The Lord of the Rings", Author = "J.R.R. Tolkien", Prize = 39.99, HardCover = true },
                new Book {Id = 4, Name = "The Witcher", Author = "Andrzej Sapkowski", Prize = 55.49, HardCover = false },
                new Book {Id = 5, Name = "The Adventures of Sherlock Holmes", Author = "Arthur Conan Doyle", Prize = 32.99, HardCover = true },
            };
        }

        public static List<Book> GetAll() => Books;

        public static Book Get(int id) => Books.FirstOrDefault(b => b.Id == id);

        public static void Add(Book book)
        {
            book.Id = nextId++;
            Books.Add(book);
        }

        public static void Delete(int id)
        {
            var book = Get(id);
            if (book is null)
                return;

            Books.Remove(book);
        }

        public static void Update(Book book)
        {
            var index = Books.FindIndex(b => b.Id == book.Id);
            if (index == -1)
                return;

            Books[index] = book;
        }
    }
}
