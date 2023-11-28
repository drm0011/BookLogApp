using BookLogApp.ViewModels;
using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForBooks
{
    public class ViewBooksModel : PageModel
    {
        private readonly IBookBLL _bookBLL;

        public BooksGenre ViewModel { get; set; }
        public ViewBooksModel()
        {
            _bookBLL = Factory.CreateBookBLL();
        }
        public List<Book> Books { get; set; }
        public void OnGet()
        {
            Books = _bookBLL.GetBooks();
            foreach(Book book in Books)
            {
                book.Genres = _bookBLL.LoadGenresForBook(book.ID);
                
            }
        }
    }
}
