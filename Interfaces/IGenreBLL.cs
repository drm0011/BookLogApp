using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IGenreBLL
    {
        void CreateGenre(string name);
        List<Genre> GetGenres();
        void UpdateGenre(Genre genre);
        Genre GetGenreById(int id);
        void DeleteGenre(int id);
        void CreateBooksGenreRelation(int bookId, int genreId);
        void DeleteBooksGenreRelationByBookId(int bookId);
    }
}
