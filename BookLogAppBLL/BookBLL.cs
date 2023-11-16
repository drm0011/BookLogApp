using BookLogAppInterfaces;
using DomainModelsLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppBLL
{
    public class BookBLL:IBookBLL
    {
        private readonly IBookRepo _bookRepo;

        public BookBLL(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public void CreateBook(string title, string author, string summary, int isbn)
        {

            try
            {
                Book book = new Book(title, author, summary, isbn);
                _bookRepo.CreateBook(book.Title, book.Author, book.Summary, book.ISBN);
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException("An error occurred while creating the book: " + ex.Message);
            }
        }

        public List<Book> GetBooks()
        {
            List<BookDTO> booksDTO = _bookRepo.GetBooks();
            List<Book> books = new List<Book>();

            // Correctly map each BookDTO to a Book domain model and add to the list
            foreach (BookDTO bookDTO in booksDTO)
            {
                books.Add(Mapper.ToDomainModel(bookDTO));
            }

            return books;
        }

    }
}
