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


        public void CreateNewGame(GameDTO game)
        {
            Game gameToCreate = new Game();
            Mapper.Map(game, gameToCreate);
            _unitOfWork.GameRepository.Create(gameToCreate);
            _unitOfWork.Commit();
        }

        public void EditGame(GameDTO game)
        {
            var gameToEdit = _unitOfWork.GameRepository.FindById(game.Id);
            Mapper.Map(game, gameToEdit);
            _unitOfWork.GameRepository.Update(gameToEdit);
            _unitOfWork.Commit();
        }

        public void DeleteGame(GameDTO game)
        {
            var gameToDelete = _unitOfWork.GameRepository.FindById(game.Id);
            _unitOfWork.GameRepository.Remove(gameToDelete);
            _unitOfWork.Commit();
        }

        public GameDTO GetGameByKey(string key)
        {
            Game game = _unitOfWork.GameRepository.Get(i => i.Key.Equals(key)).FirstOrDefault();
            GameDTO result = new GameDTO();
            Mapper.Map(game, result);
            return result;
        }

        public IEnumerable<GameDTO> GetGames()
        {
            IEnumerable<Game> games =  _unitOfWork.GameRepository.GetAll();
            IEnumerable<GameDTO> result = new List<GameDTO>();
            Mapper.Map(games, result);
            return result;
        }

        public IEnumerable<GameDTO> GetGamesByGenre(GenreDTO genre)
        {
            Genre genreEntity = new Genre();
            Mapper.Map(genreEntity, genre);
            IEnumerable<Game> games = _unitOfWork.GameRepository.Get(i => i.Genres.Contains(genreEntity));
            IEnumerable<GameDTO> result = new List<GameDTO>();
            Mapper.Map(games, result);
            return result;
        }

        public IEnumerable<GameDTO> GetGamesByPlatformType(PlatformDTO platform)
        {
            PlatformType platformEntity = new PlatformType();
            Mapper.Map(platformEntity, platform);
            IEnumerable<Game> games = _unitOfWork.GameRepository.Get(i => i.PlatformTypes.Contains(platformEntity));
            IEnumerable<GameDTO> result = new List<GameDTO>();
            Mapper.Map(games, result);
            return result;
        }
    }
}
