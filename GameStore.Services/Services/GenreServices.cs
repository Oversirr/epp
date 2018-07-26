using System.Collections.Generic;
using AutoMapper;
using GameStore.Core.Entity;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Repository;
using GameStore.Services.DTO;
using GameStore.Services.Interfaces;

namespace GameStore.Services.Services
{
    public class GenreServices : IGenreServices
    {
        private UnitOfWork _unitOfWork;

        public GenreServices()
        {
            _unitOfWork = new UnitOfWork(new GameStoreDbContext());
        }

        public void CreateNewGenre(GenreDTO genre)
        {
            Genre entity = new Genre();
            Mapper.Map(genre, entity);
            _unitOfWork.GenreRepository.Create(entity);
            _unitOfWork.Commit();
        }

        public void EditGenre(GenreDTO genre)
        {
            var genreToEdit = _unitOfWork.GenreRepository.FindById(genre.Id);
            Mapper.Map(genre, genreToEdit);
            _unitOfWork.GenreRepository.Update(genreToEdit);
            _unitOfWork.Commit();
        }

        public void DeleteGenre(GenreDTO genre)
        {
            var genreToDelete = _unitOfWork.GenreRepository.FindById(genre.Id);
            _unitOfWork.GenreRepository.Remove(genreToDelete);
            _unitOfWork.Commit();
        }

        public IEnumerable<GenreDTO> GetAllGenres()
        {
            IEnumerable<Genre> genres = _unitOfWork.GenreRepository.GetAll();
            IEnumerable<GenreDTO> result = new List<GenreDTO>();
            Mapper.Map(genres, result);
            return result;
        }
    }
}
