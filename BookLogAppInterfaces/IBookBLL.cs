using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppInterfaces
{
    public interface IBookBLL
    {
        void CreateBook(string title, string author, string summary, int isbn);
        List<Book> GetBooks();
    }
}
