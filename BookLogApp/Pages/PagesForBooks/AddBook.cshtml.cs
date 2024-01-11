using Factories;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookLogApp.Pages.PagesForBooks
{
    public class AddBookModel : PageModel
    {
        private readonly IBookBLL _bookBLL;

        public AddBookModel()
        {
            _bookBLL = Factory.CreateBookBLL();
            
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        public string Summary { get; set; }

        [BindProperty]
        public string ISBN { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            


            try
            {
                //BLL method to create the book
                _bookBLL.CreateBook(Title, Author, Summary, ISBN);

                return RedirectToPage("/Index");
            }
            catch (ArgumentException ex)
            {

                // Add the error to the ModelState to display in the view
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
