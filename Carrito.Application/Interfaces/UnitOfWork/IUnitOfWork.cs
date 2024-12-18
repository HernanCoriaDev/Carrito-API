using Carrito.Application.Interfaces.Repository;

namespace Carrito.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public ICartRepository CartsRepository { get; }
        public IProductRepository ProductsRepository { get; }
        public IUserRepository UsersRepository { get; }
        Task<int> CommitAsync();
    }
}
