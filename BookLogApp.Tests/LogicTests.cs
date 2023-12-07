using BookLogAppBLL;
using BookLogAppInterfaces;
using DomainModelsLayer;
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

            Book book = new Book("Book Title", "Book Author", "Book Summary", "12345");
            Genre genre = new Genre { Name = "Fiction" };

            book.ID = 1;
            genre.ID = 1;

            genreBLL.CreateBooksGenreRelation(book.ID, genre.ID);

            mockRepo.Verify(repo => repo.CreateBooksGenreRelation(book.ID, genre.ID), Times.Once());
        }
    }
}

