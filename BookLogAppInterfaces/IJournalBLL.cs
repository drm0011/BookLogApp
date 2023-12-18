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
        void CreateJournalEntry(string entry, int bookId);
    }
}
