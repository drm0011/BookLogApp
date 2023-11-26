using DomainModelsLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppInterfaces
{
    public interface IBookBLL
    {
        void CreateBook(string title, string author, string summary, string isbn);
        List<Book> GetBooks();
        void UpdateBook(Book book);
        Book GetBookById(int id);
        void DeleteBook(int id);
    }
}
