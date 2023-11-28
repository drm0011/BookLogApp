using BookLogApp.ViewModels;
using BookLogAppFactories;
using BookLogAppInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLogApp.Pages
{
    public class AssignGenreToBookModel : PageModel
    {
        private readonly IBookBLL _bookBLL;
        private readonly IGenreBLL _genreBLL;

        public BooksGenre ViewModel { get; set; }
        [BindProperty]
        public int SelectedBookId { get; set; }
        [BindProperty]
        public List<int> SelectedGenreIds { get; set; }
        public AssignGenreToBookModel()
        {
            _bookBLL = Factory.CreateBookBLL();
            _genreBLL = Factory.CreateGenreBLL();
        }

        public void OnGet()
        {
            ViewModel = new BooksGenre
            {
                Books = _bookBLL.GetBooks(),
                Genres = _genreBLL.GetGenres()
            };
        }

        public IActionResult OnPost()
        {
            if(SelectedBookId > 0 && SelectedGenreIds.Count > 0)
            {
                foreach(int genreId in SelectedGenreIds)
                {
                    _genreBLL.CreateBooksGenreRelation(SelectedBookId, genreId);
                }
            }

            return RedirectToPage("/PagesForBooks/ViewBooks");
        }
    }
}
