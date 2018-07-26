using System.Collections.Generic;
using GameStore.Services.DTO;

namespace GameStore.Services.Interfaces
{
    public interface ICommentsServices
    {
        void EditComment(CommentDTO comment);
        void DeleteComment(CommentDTO comment);
        void AddCommentToGame(GameDTO game, CommentDTO comment);
        void AddReplyToComment(CommentDTO comment, CommentDTO parent);
        IEnumerable<CommentDTO> GetCommentsByGameKey(string gamekey);
    }
}
