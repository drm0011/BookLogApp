using BLL;
using Interfaces;
using DomainModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogApp.Tests
{
    public class LogicTests
    {
        [Fact]
        public void AssignGenresToBook_ShouldCreateRelation()
        {
            Mock<IGenreRepo> mockRepo = new Mock<IGenreRepo>();
            GenreBLL genreBLL = new GenreBLL(mockRepo.Object);

            Book book = new Book
            {
                ID = 1,
                Title= "Book Title", 
                Author= "Book Author", 
                Summary="Book Summary", 
                ISBN="12345" 
            };
            Genre genre = new Genre {ID=1, Name = "Fiction" };

            genreBLL.CreateBooksGenreRelation(book.ID, genre.ID);

            mockRepo.Verify(repo => repo.CreateBooksGenreRelation(book.ID, genre.ID), Times.Once());
        }
    }
}

