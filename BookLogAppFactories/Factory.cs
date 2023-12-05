using BookLogAppBLL;
using BookLogAppDAL;
using BookLogAppInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppFactories
{
    public class Factory
    {
        public static IBookBLL CreateBookBLL()
        {
            return new BookBLL(new BookRepo());
        }

        public static IGenreBLL CreateGenreBLL()
        {
            return new GenreBLL(new GenreRepo());
        }
    }
}
