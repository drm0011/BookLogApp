using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //TODO: add update method, private setters <---------------


        public Genre()
        {

        }

        public Genre(string name)
        {
            ValidateGenre(name);
            Name = name;
        }

        public Genre(int id, string name) : this(name)
        {
            ID = id;
        }

        public void ValidateGenre(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Genre is empty.");
            }
        }
    }
}

