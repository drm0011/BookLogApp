using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages.PagesForGenres
{
    public class ViewGenresModel : PageModel
    {
        private readonly IGenreBLL _genreBLL;
        public ViewGenresModel()
        {
            _genreBLL=Factory.CreateGenreBLL();
        }
        public List<Genre> Genres { get; set; }

        public void OnGet()
        {
            Genres=_genreBLL.GetGenres();
        }
    }
}
