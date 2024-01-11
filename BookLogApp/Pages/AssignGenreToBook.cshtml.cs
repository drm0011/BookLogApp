using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Factories;
using DomainModels;

namespace BookLogApp.Pages
{
    public class AssignGenreToBookModel : PageModel
    {
        private readonly IBookBLL _bookBLL;
        private readonly IGenreBLL _genreBLL;

        public List<Book> Books { get; set; }
        public List<Genre> Genres { get; set;}
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
            Books = _bookBLL.GetBooks();
            Genres = _genreBLL.GetGenres();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (SelectedBookId > 0 && SelectedGenreIds.Count > 0)
                {
                    foreach (int genreId in SelectedGenreIds)
                    {
                        _genreBLL.CreateBooksGenreRelation(SelectedBookId, genreId);
                    }
                    return RedirectToPage("/PagesForBooks/ViewBooks");
                }

            }
            catch (Exception)
            {
                Books = _bookBLL.GetBooks();
                Genres = _genreBLL.GetGenres();

                ModelState.AddModelError(string.Empty, "An error occured assigning genres to your book");
                return Page();
            }

            Books = _bookBLL.GetBooks();
            Genres = _genreBLL.GetGenres();

            return Page();
        }
    }
}
