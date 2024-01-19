using BLL;
using Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogApp.Tests
{
    public class JournalBLLTests
    {
        [Fact]
        public void AnalyzeMood_IdentifiesHappyMood()
        {
            Mock<IJournalRepo> mockRepo = new Mock<IJournalRepo>();
            JournalBLL journalBLL = new JournalBLL(mockRepo.Object);
            string journalEntry = "This was a happy book";

            string mood = journalBLL.AnalyzeMood(journalEntry);

            Assert.Equal("Happy", mood);
        }

        [Fact]
        public void AnalyzeMood_IdentifiesSadMood()
        {
            Mock<IJournalRepo> mockRepo = new Mock<IJournalRepo>();
            JournalBLL journalBLL = new JournalBLL(mockRepo.Object);
            string journalEntry = "This was a sad book";

            string mood = journalBLL.AnalyzeMood(journalEntry);

            Assert.Equal("Sad", mood);
        }

        [Fact]
        public void AnalyzeMood_ReturnUndefinedMood()
        {
            Mock<IJournalRepo> mockRepo = new Mock<IJournalRepo>();
            JournalBLL journalBLL = new JournalBLL(mockRepo.Object);
            string journalEntry = "This was just a book";

            string mood = journalBLL.AnalyzeMood(journalEntry);

            Assert.Equal("Undefined mood", mood);
        }
        [Fact]
        public void AnalyzeMood_IdentifiesPredominantMood()
        {
            Mock<IJournalRepo> mockRepo = new Mock<IJournalRepo>();
            JournalBLL journalBLL = new JournalBLL(mockRepo.Object);

            string journalEntry = "This book was interesting but a bit boring.";

            string mood = journalBLL.AnalyzeMood(journalEntry);

            Assert.Equal("Boring", mood);
        }
    }
}
