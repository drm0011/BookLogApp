﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IGenreRepo
    {
        void CreateGenre(string name);
        List<GenreDTO> GetGenres();
        void UpdateGenre(int id, string name);
        GenreDTO GetGenreById(int id);
        void DeleteGenre(int id);
        void CreateBooksGenreRelation(int bookId, int genreId);
        void DeleteBooksGenreRelationByBookId(int bookId);
    }
}
