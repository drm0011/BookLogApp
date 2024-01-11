using BLL;
using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
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

        public static IJournalBLL CreateJournalBLL()
        {
            return new JournalBLL(new JournalRepo());
        }
    }
}
