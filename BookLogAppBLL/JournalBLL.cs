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
        private Dictionary<string, List<(string word, int score)>> _moodKeywords;
        public JournalBLL(IJournalRepo journalRepo)
        {
            _journalRepo = journalRepo;
            _moodKeywords = new Dictionary<string, List<(string word, int score)>>
            {
                { "Happy", new List<(string word, int score)> { ("joy", 1), ("happy", 1), ("delighted", 2) } },
                { "Sad", new List<(string word, int score)> { ("sad", 1), ("depressed", 2), ("unhappy", 1) } },
                { "Interesting", new List<(string word, int score)> {("interesting", 1), ("stimulating", 1)} },
            };
        }
        public string AnalyzeMood(string journalEntry)
        {
            Dictionary<string, int> moodScores = new Dictionary<string, int>();
            bool isAnyMoodScored = false;

            foreach (string mood in _moodKeywords.Keys)
            {
                moodScores[mood] = 0;
                foreach ((string word, int score) in _moodKeywords[mood])
                {
                    if (journalEntry.IndexOf(word, StringComparison.OrdinalIgnoreCase)>=0)
                    {
                        moodScores[mood] += score;
                        isAnyMoodScored = true;
                    }
                }
            }

            if (!isAnyMoodScored)
            {
                return "Undefined mood"; 
            }

            string predominantMood = moodScores.OrderByDescending(kv => kv.Value).First().Key;
            return predominantMood;
        }
        public Journal GetEntryAndBookById(int id, int bookId)
        {
            JournalDTO journalDTO = _journalRepo.GetEntryAndBookById(id, bookId);
            {
                return Mapper.ToDomainModel(journalDTO);
            }

            return null;
        }
        public void UpsertJournalEntry(string entry, int bookId)
        {
            try
            {
                _journalRepo.UpsertJournalEntry(entry, bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetJournalEntryIdForBook(int bookId)
        {
            return _journalRepo.GetJournalEntryIdForBook(bookId);
        }
    }
}
