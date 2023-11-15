using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; private set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }

        public Book(string title, string author, string summary, int isbn)
        {
            SetTitle(title);
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title is empty!");
            }

            Title = title;
        }
    }
}
