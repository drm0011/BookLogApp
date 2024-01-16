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
        public string? Summary { get; init; }
        public string Author { get; init; }
        public string ISBN { get; init; }
        public List<Genre> Genres { get; set; }

        //public List<int> SelectedGenreIds { get; set; }

        //TODO: add update method, private setters <---------------

        //constructor update form binding
        //view model ui, geen constructors nodig door init, validatie naar bll
      
    }
}

