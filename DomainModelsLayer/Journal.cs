using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainModelsLayer
{
    public class Journal
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Entry { get; set; }


        public Journal()
        {

        }
        public Journal(string entry, int bookId)
        {
            ValidateEntry(entry, bookId);
            Entry = entry;
            BookID = bookId;
        }
        public Journal(int id, string entry, int bookId) : this(entry, bookId)
        {
            ID = id;
        }
        public void ValidateEntry(string entry, int bookId)
        {
            if (string.IsNullOrEmpty(entry))
            {
                throw new ArgumentException("Journal entry is empty.");
            }
            if (bookId==0)
            {
                throw new ArgumentException("No book selected.");
            }
        }
    }
}
