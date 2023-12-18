using BookLogAppInterfaces;
using DomainModelsLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppBLL
{
    public class JournalBLL:IJournalBLL
    {
        private readonly IJournalRepo _journalRepo;
        public JournalBLL(IJournalRepo journalRepo)
        {
            _journalRepo = journalRepo;
        }
        public Journal GetEntryAndBookById(int id, int bookId)
        {
            JournalDTO journalDTO = _journalRepo.GetEntryAndBookById(id, bookId);
            {
                return Mapper.ToDomainModel(journalDTO);
            }

            return null;
        }
        public void CreateJournalEntry(string entry, int bookId)
        {
            try
            {
                _journalRepo.CreateJournalEntry(entry, bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
