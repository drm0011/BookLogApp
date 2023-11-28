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
    public class GenreBLL:IGenreBLL
    {
        private readonly IGenreRepo _genreRepo;
        public GenreBLL(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public void CreateGenre(string name)
        {
            _genreRepo.CreateGenre(name);
        }

        public void DeleteGenre(int id)
        {
            _genreRepo.DeleteGenre(id);
        }

        public Genre GetGenreById(int id)
        {
            GenreDTO genreDTO=_genreRepo.GetGenreById(id);
            if (genreDTO != null)
            {
                return Mapper.ToDomainModel(genreDTO);
            }

            return null;
        }

        public List<Genre> GetGenres()
        {
            List<GenreDTO> genresDTO = _genreRepo.GetGenres();
            List<Genre> genres = new List<Genre>();

            foreach (GenreDTO genreDTO in genresDTO)
            {
                genres.Add(Mapper.ToDomainModel(genreDTO));
            }

            return genres;
        }

        public void UpdateGenre(Genre genre)
        {
            _genreRepo.UpdateGenre(genre.ID, genre.Name);   
        }

        public void CreateBooksGenreRelation(int bookId, int genreId)
        {
            _genreRepo.CreateBooksGenreRelation(bookId, genreId);
        }

    }
}
