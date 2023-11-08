using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppInterfaces
{
    public interface IBookRepo
    {
        void CreateBook(string title, string author, string summary, int isbn);
        List<BookDTO> GetBooks();
    }
}
