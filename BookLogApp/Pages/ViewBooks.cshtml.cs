using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages
{
    public class ViewBooksModel : PageModel
    {
        private readonly IBookBLL _bookBLL;

        public ViewBooksModel()
        {
            _bookBLL=BookFactory.CreateBookBLL();
        }

        public List<Book> Books { get; set; }   
        public void OnGet()
        {
            Books=_bookBLL.GetBooks();
        }
    }
}
