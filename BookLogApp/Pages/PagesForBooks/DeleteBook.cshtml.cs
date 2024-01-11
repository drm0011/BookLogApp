using DomainModels;
using Factories;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForBooks
{
    public class DeleteBookModel : PageModel
    {
        //prevent navigation through url to this page
        private readonly IBookBLL _bookBLL;

        public DeleteBookModel()
        {
            _bookBLL = Factory.CreateBookBLL();
        }
        public Book Book { get; set; }
        public IActionResult OnGet(int id)
        {
            _bookBLL.DeleteBook(id);
            return RedirectToPage("./ViewBooks");
        }
    }
}
