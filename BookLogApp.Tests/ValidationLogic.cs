using BLL;
using DAL;
using DomainModels;
using Interfaces;
using Moq;

namespace BookLogApp.Tests
{
    public class ValidationLogic
    {
        [Fact]
        public void CreateBook_WithValidInput()
        {
            Mock<IBookRepo> mockRepo = new Mock<IBookRepo>();
            BookBLL bookBLL = new BookBLL(mockRepo.Object);

            string title = "Book Title";
            string author = "Book Author";
            string summary = "Book Summary";
            string isbn = "12345";

            bookBLL.CreateBook(title, author, summary, isbn);
            Book book = new Book
            {
                Title = title,
                Author = author,
                Summary = summary,
                ISBN = isbn
            };


            Assert.NotNull(book);
            Assert.Equal(title, book.Title);
        }

        [Fact]
        public void CreateBook_WithInvalidInput() {
            Mock<IBookRepo> mockRepo = new Mock<IBookRepo>();
            BookBLL bookBLL = new BookBLL(mockRepo.Object);

            string title = "";
            string author = "";
            string summary = "";
            string isbn = "";
            Exception exception = null;

            try
            {
                bookBLL.CreateBook(title, author, summary, isbn);
            }
            catch (Exception ex)
            {

                exception=ex;
            }

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }
    }
}
