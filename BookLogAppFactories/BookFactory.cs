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
    public class BookFactory
    {
        public static IBookBLL CreateBookBLL()
        {
            return new BookBLL(new BookRepo());
        }
    }
}
