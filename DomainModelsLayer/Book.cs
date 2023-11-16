using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelsLayer
{
    public class Book
    {
        public int ID { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }


        //constructor for creating book
        public Book(string title, string author, string summary, string isbn)
        {
            ValidateBookDetails(title, author, summary, isbn);

            Title = title;
            Summary = summary;
            Author = author;
            ISBN = isbn;
        }

        //constructor existing book
        public Book(int id, string title, string author, string summary, string isbn) : this(title, author, summary, isbn)
        {
            ID = id;
        }

        public void ValidateBookDetails(string title, string author, string summary, string isbn)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title is empty.");
            }
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Author is empty.");
            }
            if (string.IsNullOrEmpty(isbn)) //TODO: further validation for ISBN 
            {
                throw new ArgumentException("Invalid ISBN.");
            }
        }

    }
}
