using BookLogAppBLL;
using BookLogAppFactories;
using BookLogAppInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForGenres
{
    public class AddGenreModel : PageModel
    {
        private readonly IGenreBLL _genreBLL;
        public AddGenreModel()
        {
            _genreBLL = Factory.CreateGenreBLL();
        }

        [BindProperty]
        public string Name { get; set; }
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
                _genreBLL.CreateGenre(Name);

                return RedirectToPage("/Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
