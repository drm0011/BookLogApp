using DomainModels;
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
    }
}
