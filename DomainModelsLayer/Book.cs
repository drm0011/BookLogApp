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
        public int ISBN { get; private set; }

        public Book(string title, string author, string summary, int isbn)
        {
            SetBookDetails(title, author, summary);
            ISBN = isbn;
        }

        public void SetBookDetails(string title, string author, string summary)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) ||
                string.IsNullOrEmpty(summary))
            {
                throw new ArgumentException("Fill in the missing fields");
            }

            Title = title;
            Summary = summary;
            Author = author;
        }

        public void SetId(int id)
        {
            ID = id;
        }
    }
}
