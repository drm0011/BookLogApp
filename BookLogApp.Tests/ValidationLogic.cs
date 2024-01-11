using BLL;
using DAL;
using DomainModels;

namespace BookLogApp.Tests
{
    public class ValidationLogic
    {
        [Fact]
        public void CreateBook_WithValidInput()
        {
            string title = "Book Title";
            string author = "Book Author";
            string summary = "Book Summary";
            string isbn = "12345";

            Book book = new Book(title, author, summary, isbn);

            Assert.NotNull(book);
            Assert.Equal(title, book.Title);
        }

        [Fact]
        public void CreateBook_WithInvalidInput() {
            string title = "";
            string author = "";
            string summary = "";
            string isbn = "";
            Exception exception = null;

            try
            {
                Book book = new Book(title, author, summary, isbn);
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
