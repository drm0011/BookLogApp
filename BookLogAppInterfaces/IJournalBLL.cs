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
        Journal GetEntryAndBookById(int id, int bookId);
        void UpsertJournalEntry(string entry, int bookId);
        int GetJournalEntryIdForBook(int bookId);
    }
}
