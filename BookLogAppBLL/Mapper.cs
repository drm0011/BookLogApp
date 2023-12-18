using DomainModelsLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppBLL
{
    public class Mapper
    {
        public static Book ToDomainModel(BookDTO dto)
        {
            Book book = new Book(dto.ID, dto.Title, dto.Author, dto.Summary, dto.ISBN);
            return book;

        }

        public static BookDTO ToDTO(Book domainModel)
        {
            return new BookDTO
            {
                ID = domainModel.ID,
                Title = domainModel.Title,
                Summary = domainModel.Summary,
                Author = domainModel.Author,
                ISBN = domainModel.ISBN
            };
        }

        public static Genre ToDomainModel(GenreDTO dto)
        {
            Genre genre = new Genre(dto.ID, dto.Name);
            return genre;
        }

        public static GenreDTO ToDTO(GenreDTO domainModel)
        {
            return new GenreDTO
            {
                ID = domainModel.ID,
                Name = domainModel.Name,
            };
        }

        public static Journal ToDomainModel(JournalDTO dto)
        {
            Journal journal = new Journal(dto.ID, dto.Entry, dto.BookID);
            return journal;
        }

        public static JournalDTO ToDTO(JournalDTO domainModel)
        {
            return new JournalDTO
            {
                ID = domainModel.ID,
                Entry = domainModel.Entry,
                BookID = domainModel.BookID,
            };
        }
    }
}
