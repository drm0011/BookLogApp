﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBookRepo
    {
        void CreateBook(string title, string author, string summary, string isbn);
        List<BookDTO> GetBooks();
        void UpdateBook(int id, string title, string author, string summary);
        BookDTO GetBookById(int id);
        void DeleteBook(int id);
        List<GenreDTO> LoadGenresForBook(int id);
    }
}
