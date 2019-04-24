using Shop.Data.Models;
using Shop.Service.GenericRepository;
using System;
using System.Threading.Tasks;

namespace Shop.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Product> ProductRepository { get; private set; }

        public IGenericRepository<Category> CategoryRepository { get; private set; }

        public IGenericRepository<Rating> RatingRepository { get; private set; }

        public IGenericRepository<User> UserRepository { get; private set; }

        public IGenericRepository<Image> ImageRepository { get; private set; }

        public IGenericRepository<Color> ColorRepository { get; private set; }

        public IGenericRepository<Size> SizeRepository { get; private set; }

        private ApplicationDataContext _context;

        private bool _disposed = false;

        public UnitOfWork(ApplicationDataContext context)
        {
            _context = context;
            ProductRepository = new GenericRepository<Product>(_context);
            CategoryRepository = new GenericRepository<Category>(_context);
            RatingRepository = new GenericRepository<Rating>(_context);
            UserRepository = new GenericRepository<User>(_context);
            ImageRepository = new GenericRepository<Image>(_context);
            ColorRepository = new GenericRepository<Color>(_context);
            SizeRepository = new GenericRepository<Size>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
