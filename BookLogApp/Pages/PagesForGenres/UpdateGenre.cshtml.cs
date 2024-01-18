using BookLogApp.ViewModels;
using DomainModels;
using Factories;
using Interfaces;
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
        public GenreViewModel GenreViewModel { get; set; }
        public void OnGet(int id)
        {
            Genre genre = _genreBLL.GetGenreById(id);
            GenreViewModel = new GenreViewModel
            {
                ID = genre.ID,
                Name = genre.Name
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Genre genreToUpdate = new Genre
            {
                ID = GenreViewModel.ID,
                Name = GenreViewModel.Name
            };

            try
            {
                _genreBLL.UpdateGenre(genreToUpdate);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }

            return RedirectToPage("./ViewGenres");
        }
    }
}
