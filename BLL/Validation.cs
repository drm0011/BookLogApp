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
            if (string.IsNullOrEmpty(title)) //is null or white space?
            {
                throw new ArgumentException("Title is empty.");
            }
            if (string.IsNullOrEmpty(author))
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
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Genre is empty.");
            }
        }
    }
}
