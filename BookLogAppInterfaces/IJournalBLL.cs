using DomainModelsLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppInterfaces
{
    public interface IJournalBLL
    {
        Journal GetJournalEntryForBook(int bookId);
        void UpsertJournalEntry(string entry, int bookId);
        string AnalyzeMood(string journalEntry);
    }
}
