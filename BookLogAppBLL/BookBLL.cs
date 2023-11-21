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

        #region book crud methods
        public void CreateBook(string title, string author, string summary, string isbn)
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

        public void UpdateBook(Book book)
        {
            try
            {
                _bookRepo.UpdateBook(book.ID, book.Title, book.Author, book.Summary);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Book GetBookById(int id)
        {
            BookDTO bookDTO = _bookRepo.GetBookById(id);
            if (bookDTO != null)
            {
                return Mapper.ToDomainModel(bookDTO);
            }

            return null; //return null if no book is found
        }

        #endregion
    }
}
