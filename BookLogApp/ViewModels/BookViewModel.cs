using DomainModels;

namespace BookLogApp.ViewModels
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public List<int> SelectedGenreIds { get; set; }
        public List<Genre> AvailableGenres { get; set; }
        public BookViewModel()
        {
            SelectedGenreIds = new List<int>();
            AvailableGenres = new List<Genre>();
        }
    }
}
