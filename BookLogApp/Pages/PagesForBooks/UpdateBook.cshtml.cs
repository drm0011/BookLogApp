using BLL;
using Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DomainModels;
using Interfaces;

namespace BookLogApp.Pages.PagesForBooks
{
    public class UpdateBookModel : PageModel
    {
        private readonly IBookBLL _bookBLL;
        private readonly IGenreBLL _genreBLL;


        public UpdateBookModel()
        {
            _bookBLL = Factory.CreateBookBLL();
            _genreBLL=Factory.CreateGenreBLL();
        }

        [BindProperty]
        public List<Genre> AllGenres { get; set; }

        [BindProperty]
        public Book Book { get; set; } //TODO: create viewmodel for ui?
        [BindProperty]
        public List<int> SelectedGenreIds { get; set; } 
        public void OnGet(int id)
        {
            Book = _bookBLL.GetBookById(id);
            AllGenres = _genreBLL.GetGenres();
            List<Genre> bookGenres = _bookBLL.LoadGenresForBook(id);
            SelectedGenreIds=bookGenres.Select(g=>g.ID).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _bookBLL.UpdateBook(Book);

            _genreBLL.DeleteBooksGenreRelationByBookId(Book.ID);

            foreach (int genreId in SelectedGenreIds)
            {
                _genreBLL.CreateBooksGenreRelation(Book.ID, genreId);
            }

            return RedirectToPage("./ViewBooks");
        }
    }
}
