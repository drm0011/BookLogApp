using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Validation
    {
        public static void ValidateBookDetails(string title, string author, string summary, string isbn)
        {
            if (string.IsNullOrWhiteSpace(title)) //is null or white space?
            {
                throw new ArgumentException("Title is empty.");
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author is empty.");
            }
            if (string.IsNullOrWhiteSpace(isbn)) //TODO: further validation for ISBN 
            {
                throw new ArgumentException("Invalid ISBN.");
            }
        }

        public static void ValidateGenre(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Genre is empty.");
            }
        }

        public static void ValidateEntry(string entry, int bookId)
        {
            if (string.IsNullOrWhiteSpace(entry))
            {
                throw new ArgumentException("Journal entry is empty.");
            }
            if (bookId == 0)
            {
                throw new ArgumentException("No book selected.");
            }
        }
    }
}
