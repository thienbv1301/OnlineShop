using Shop.Data.Models;
using Shop.Service.GenericRepository;
using System;
using System.Threading.Tasks;

namespace Shop.Service.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Rating> RatingRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Image> ImageRepository { get; }
        IGenericRepository<Color> ColorRepository { get; }
        IGenericRepository<Size> SizeRepository { get; }
        Task SaveAsync();
    }
}
