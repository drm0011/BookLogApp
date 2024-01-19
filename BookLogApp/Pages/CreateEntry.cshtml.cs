using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DomainModels;
using Interfaces;
using Factories;

namespace BookLogApp.Pages
{
    public class CreateEntryModel : PageModel
    {
        private readonly IBookBLL _bookBLL;
        private readonly IJournalBLL _journalBLL;
        public Book Book { get; set; }
        public Journal Journal { get; set; }
        public string AnalyzedMood { get; set; }
        [BindProperty]
        public string Entry { get; set; }
        public CreateEntryModel()
        {
            _bookBLL = Factory.CreateBookBLL();
            _journalBLL = Factory.CreateJournalBLL();
        }
        public void OnGet(int id)
        {
            Book = _bookBLL.GetBookById(id);
            if (Book != null)
            {
                //TODO: simplify code, and error handling
                int journalId = _journalBLL.GetJournalEntryIdForBook(id);

                Journal journalEntry = _journalBLL.GetEntryAndBookById(journalId, id);
                if (journalEntry != null)
                {
                    Entry = journalEntry.Entry;
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                 Book = _bookBLL.GetBookById(id);
                _journalBLL.UpsertJournalEntry(Entry, Book.ID);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            
            return Page();
        }

        public IActionResult OnPostAnalyze(int id)
        {
            try
            {
                Book = _bookBLL.GetBookById(id);
                if (!string.IsNullOrEmpty(Entry))
                {
                    AnalyzedMood = _journalBLL.AnalyzeMood(Entry);
                }
                _journalBLL.UpsertJournalEntry(Entry, Book.ID);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            
            return Page();
        }
    }
}
