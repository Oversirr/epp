using System;
using GameStore.Core.Entity;
using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Data;

namespace GameStore.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _context;
        private readonly Lazy<GenericRepository<Game>> _lazyGameRepository;
        private readonly Lazy<GenericRepository<Comment>> _lazyCommentRepository;
        private readonly Lazy<GenericRepository<Genre>> _lazyGenreRepository;
        private readonly Lazy<GenericRepository<PlatformType>> _lazyPlatformTypeRepository;

        public UnitOfWork(GameStoreDbContext context)
        {
            _context = context;
            _lazyCommentRepository = new Lazy<GenericRepository<Comment>>(() => new GenericRepository<Comment>(context));
            _lazyGameRepository = new Lazy<GenericRepository<Game>>(() => new GenericRepository<Game>(context));
            _lazyGenreRepository = new Lazy<GenericRepository<Genre>>(() => new GenericRepository<Genre>(context));
            _lazyPlatformTypeRepository = new Lazy<GenericRepository<PlatformType>>(() => new GenericRepository<PlatformType>(context));
        }

        public IGenericRepository<Game> GameRepository => _lazyGameRepository.Value;
        public IGenericRepository<Genre> GenreRepository => _lazyGenreRepository.Value;
        public IGenericRepository<Comment> CommentRepository => _lazyCommentRepository.Value;
        public IGenericRepository<PlatformType> PlatformTypeRepository => _lazyPlatformTypeRepository.Value;

        public void Commit() => _context.SaveChanges();
    }
}
