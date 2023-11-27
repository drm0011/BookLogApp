using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForBooks
{
    public class UpdateBookModel : PageModel
    {
        private readonly IBookBLL _bookBLL;

        public UpdateBookModel()
        {
            _bookBLL = Factory.CreateBookBLL();
        }

        [BindProperty]
        public Book Book { get; set; } //TODO: create viewmodel for ui?
        public void OnGet(int id)
        {
            Book = _bookBLL.GetBookById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookBLL.UpdateBook(Book);
            return RedirectToPage("./ViewBooks");
        }
    }
}
