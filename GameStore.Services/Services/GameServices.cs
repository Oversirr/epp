using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameStore.Core.Entity;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Repository;
using GameStore.Services.DTO;
using GameStore.Services.Interfaces;

namespace GameStore.Services.Services
{
    public class GameServices : IGameServices
    {
        private UnitOfWork _unitOfWork;

        public GameServices()
        {
            _unitOfWork = new UnitOfWork(new GameStoreDbContext());
        }

        public void CreateNewGame(GameCreateDTO game)
        {
            Game gameToCreate = new Game();
            Mapper.Map(game, gameToCreate);
            SetGenres(game, gameToCreate);
            SetPlatforms(game, gameToCreate);
            if (_unitOfWork.GameRepository.Get(i => i.Key.Equals(game.Key)).ToList().Count == 0)
            {
                _unitOfWork.GameRepository.Create(gameToCreate);
                _unitOfWork.Commit();
            }
        }

        public void EditGame(GameEditDTO game)
        {
            var gameToEdit = _unitOfWork.GameRepository.FindById(game.Id);
            Mapper.Map(game, gameToEdit);
            SetGenres(game, gameToEdit);
            SetPlatforms(game, gameToEdit);
            if (_unitOfWork.GameRepository.Get(i => i.Key.Equals(game.Key)) == null)
            {
                _unitOfWork.GameRepository.Update(gameToEdit);
                _unitOfWork.Commit();
            }
        }

        public void DeleteGame(GameEditDTO game)
        {
            var gameToDelete = _unitOfWork.GameRepository.FindById(game.Id);
            _unitOfWork.GameRepository.Remove(gameToDelete);
            _unitOfWork.Commit();
        }

        public GameShowDTO GetGameByKey(string key)
        {
            Game game = _unitOfWork.GameRepository.Get(i => i.Key.Equals(key)).FirstOrDefault();
            GameShowDTO result = new GameShowDTO();
            Mapper.Map(game, result);
            return result;
        }

        public IEnumerable<GameShowDTO> GetGames()
        {
            IEnumerable<Game> games = _unitOfWork.GameRepository.GetAll();
            IEnumerable<GameShowDTO> result = new List<GameShowDTO>();
            Mapper.Map(games, result);
            return result;
        }

        public IEnumerable<GameShowDTO> GetGamesByGenre(GenreDTO genre)
        {
            Genre genreEntity = new Genre();
            Mapper.Map(genreEntity, genre);
            IEnumerable<Game> games = _unitOfWork.GameRepository.Get(i => i.Genres.Contains(genreEntity));
            IEnumerable<GameShowDTO> result = new List<GameShowDTO>();
            Mapper.Map(games, result);
            return result;
        }

        public IEnumerable<GameShowDTO> GetGamesByPlatformType(PlatformDTO platform)
        {
            PlatformType platformEntity = new PlatformType();
            Mapper.Map(platformEntity, platform);
            IEnumerable<Game> games = _unitOfWork.GameRepository.Get(i => i.PlatformTypes.Contains(platformEntity));
            IEnumerable<GameShowDTO> result = new List<GameShowDTO>();
            Mapper.Map(games, result);
            return result;
        }

        private void SetPlatforms(IGameDTO game, Game gameToDataBase)
        {
            gameToDataBase.PlatformTypes = new List<PlatformType>();
            foreach (var items in game.PlatformTypes)
            {
                gameToDataBase.PlatformTypes.Add(_unitOfWork.PlatformTypeRepository.FindById(items.Id));
            }
        }

        private void SetGenres(IGameDTO game, Game gameToDataBase)
        {
            gameToDataBase.Genres = new List<Genre>();
            foreach (var items in game.Genres)
            {
                gameToDataBase.Genres.Add(_unitOfWork.GenreRepository.FindById(items.Id));
            }
        }
    }
}
