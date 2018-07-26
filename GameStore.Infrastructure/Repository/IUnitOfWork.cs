using GameStore.Core.Entity;
using GameStore.Core.Interfaces;

namespace GameStore.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Game> GameRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<PlatformType> PlatformTypeRepository { get; }
        void Commit();
    }
}