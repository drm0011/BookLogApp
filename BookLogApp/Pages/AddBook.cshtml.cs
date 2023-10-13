using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BookLogAppBLL;  
using BookLogAppFactories; 
using BookLogAppInterfaces;

namespace BookLogApp.Pages
{
    public class AddBookModel : PageModel
    {
        private readonly IBookBLL _bookBLL;

        public AddBookModel()
        {
            _bookBLL = BookFactory.CreateBookBLL();
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        public string Summary { get; set; }

        [BindProperty]
        public int ISBN { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //BLL method to create the book
            _bookBLL.CreateBook(Title, Author, Summary, ISBN);

            return RedirectToPage("/Index"); 
        }
    }
}
