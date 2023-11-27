using BookLogAppBLL;
using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForGenres
{
    public class UpdateGenreModel : PageModel
    {
        private readonly IGenreBLL _genreBLL;
        public UpdateGenreModel()
        {
            _genreBLL=Factory.CreateGenreBLL();
        }
        [BindProperty]
        public Genre Genre { get; set; }    
        public void OnGet(int id)
        {
            Genre=_genreBLL.GetGenreById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _genreBLL.UpdateGenre(Genre);
            return RedirectToPage("./ViewGenres");
        }
    }
}
