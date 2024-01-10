using BookLogAppFactories;
using BookLogAppInterfaces;
using DomainModelsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

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
        public string JournalEntry { get; set; }
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

                Journal journalEntry = _journalBLL.GetJournalEntryForBook(id);
                if (journalEntry != null)
                {
                    JournalEntry = journalEntry.Entry;
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            Book = _bookBLL.GetBookById(id);
            _journalBLL.UpsertJournalEntry(JournalEntry, Book.ID);
            return Page();
        }

        public IActionResult OnPostAnalyze(int id)
        {
            Book = _bookBLL.GetBookById(id);
            if (!string.IsNullOrEmpty(JournalEntry))
            {
                AnalyzedMood = _journalBLL.AnalyzeMood(JournalEntry);
            }
            return Page();
        }
    }
}
