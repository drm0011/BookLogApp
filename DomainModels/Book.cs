using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Book
    {
        public int ID { get; init; }
        public string Title { get; init; }
        public string Summary { get; init; }
        public string Author { get; init; }
        public string ISBN { get; init; }
        public List<Genre> Genres { get; set; }

        //public List<int> SelectedGenreIds { get; set; }

        //TODO: add update method, private setters <---------------

        //constructor update form binding
        //view model ui, geen constructors nodig door init, validatie naar bll
        public Book() { }
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
            if (string.IsNullOrWhiteSpace(isbn)) //TODO: further validation for ISBN 
            {
                throw new ArgumentException("Invalid ISBN.");
            }
        }

    }
}

