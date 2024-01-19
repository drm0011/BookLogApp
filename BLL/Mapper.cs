using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class Mapper
    {
        public static Book ToDomainModel(BookDTO dto)
        {
            return new Book 
            {
                ID = dto.ID,
                Title = dto.Title,
                Summary = dto.Summary,
                Author = dto.Author,
                ISBN = dto.ISBN
            };

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
            return new Genre
            {
                ID = dto.ID,
                Name = dto.Name
            };
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
            return new Journal
            {
                ID = dto.ID,
                Entry = dto.Entry,
                BookID = dto.BookID
            };
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
