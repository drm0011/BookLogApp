using BLL;
using Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DomainModels;
using BookLogApp.ViewModels;
using System.Linq;
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
            _genreBLL = Factory.CreateGenreBLL();
        }

        [BindProperty]
        public BookViewModel BookViewModel { get; set; }

        public void OnGet(int id)
        {
            Book book = _bookBLL.GetBookById(id);
            BookViewModel = new BookViewModel
            {
                ID = book.ID,
                Title = book.Title,
                Summary = book.Summary,
                Author = book.Author,
                ISBN = book.ISBN,
                AvailableGenres = _genreBLL.GetGenres(),
                SelectedGenreIds = _bookBLL.LoadGenresForBook(id).Select(g => g.ID).ToList()
            };
        }

        public IActionResult OnPost()
        {
            if (BookViewModel == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                BookViewModel.AvailableGenres = _genreBLL.GetGenres();
                BookViewModel.SelectedGenreIds = _bookBLL.LoadGenresForBook(BookViewModel.ID).Select(g => g.ID).ToList();
                return Page();
            }

            Book bookToUpdate = new Book
            {
                ID = BookViewModel.ID,
                Title = BookViewModel.Title,
                Author = BookViewModel.Author,
                Summary = BookViewModel.Summary,
                ISBN = BookViewModel.ISBN
            };

            _bookBLL.UpdateBook(bookToUpdate);

            _genreBLL.DeleteBooksGenreRelationByBookId(bookToUpdate.ID);
            foreach (int genreId in BookViewModel.SelectedGenreIds)
            {
                _genreBLL.CreateBooksGenreRelation(bookToUpdate.ID, genreId);
            }
            return RedirectToPage("./ViewBooks");
        }
    }
}
