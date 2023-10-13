using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppBLL
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
    }
}
