using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForGenres
{
    public class DeleteGenreModel : PageModel
    {
        private readonly IGenreBLL _genreBLL;
        public DeleteGenreModel()
        {
            _genreBLL=Factory.CreateGenreBLL();
        }
        public Genre Genre { get; set; }
        public IActionResult OnGet(int id)
        {
            _genreBLL.DeleteGenre(id);
            return RedirectToPage("./ViewGenres");
        }
    }
}
