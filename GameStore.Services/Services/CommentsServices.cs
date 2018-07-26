using System.Collections.Generic;
using AutoMapper;
using GameStore.Core.Entity;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Repository;
using GameStore.Services.DTO;
using GameStore.Services.Interfaces;

namespace GameStore.Services.Services
{
    public class CommentsServices : ICommentsServices
    {
        private UnitOfWork _unitOfWork;

        public CommentsServices()
        {
            _unitOfWork = new UnitOfWork(new GameStoreDbContext());
        }


        public void EditComment(CommentDTO comment)
        {
            var commentToEdit = _unitOfWork.CommentRepository.FindById(comment.Id);
            Mapper.Map(comment, commentToEdit);
            _unitOfWork.CommentRepository.Update(commentToEdit);
            //_unitOfWork.CommentRepository.Update(comment, commentToEdit);
            _unitOfWork.Commit();
        }

        public void DeleteComment(CommentDTO comment)
        {
            var commentToDelete = _unitOfWork.CommentRepository.FindById(comment.Id);
            _unitOfWork.CommentRepository.Remove(commentToDelete);
            _unitOfWork.Commit();
        }

        public void AddCommentToGame(GameDTO game, CommentDTO comment)
        {
            var commentToAdd = new Comment(); //PH until map comment here
            var targetGame = new Game();
            Mapper.Map(comment, commentToAdd);
            Mapper.Map(game, targetGame);
            commentToAdd.Game = targetGame;
            _unitOfWork.CommentRepository.Create(commentToAdd);
            _unitOfWork.Commit();
        }

        public void AddReplyToComment(CommentDTO comment, CommentDTO parent)
        {
            var commentToAdd = new Comment(); //PH until map comment here
            var parrentComment = _unitOfWork.CommentRepository.FindById(parent.Id);
            Mapper.Map(comment, commentToAdd);
            commentToAdd.ParrentComment = parrentComment;
            _unitOfWork.CommentRepository.Create(commentToAdd);
            _unitOfWork.Commit();
        }

        public IEnumerable<CommentDTO> GetCommentsByGameKey(string gamekey)
        {
            IEnumerable<CommentDTO> result = new List<CommentDTO>();
            IEnumerable<Comment> comments = _unitOfWork.CommentRepository.Get(i => i.Game.Key.Equals(gamekey));
            Mapper.Map(comments, result);
            return result;
        }
    }
}
