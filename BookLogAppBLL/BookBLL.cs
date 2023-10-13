using BookLogAppInterfaces;
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
            // Simple validation
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be empty");
            if (string.IsNullOrEmpty(author))
                throw new ArgumentException("Author cannot be empty");
            if (isbn <= 0)
                throw new ArgumentException("Invalid ISBN number");


            _bookRepo.CreateBook(title, author, summary, isbn);
        }

    }
}
