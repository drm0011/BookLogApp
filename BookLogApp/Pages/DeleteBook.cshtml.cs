using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages
{
    public class DeleteBookModel : PageModel
    {
        //prevent navigation through url to this page
        private readonly IBookBLL _bookBLL;

        public DeleteBookModel()
        {
            _bookBLL=BookFactory.CreateBookBLL();
        }
        public Book Book { get; set; }
        public IActionResult OnGet(int id)
        {
            _bookBLL.DeleteBook(id);
            return RedirectToPage("./ViewBooks");
        }
    }
}
