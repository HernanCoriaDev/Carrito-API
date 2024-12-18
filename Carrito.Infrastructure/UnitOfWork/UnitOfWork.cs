using Carrito.Application.Interfaces.Repository;
using Carrito.Application.Interfaces.UnitOfWork;
using Carrito.Infrastructure.DataBase;
using Carrito.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ICartRepository CartsRepository { get; }
    public IProductRepository ProductsRepository { get; }
    public IUserRepository UsersRepository { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        CartsRepository = new CartRepository(_context);
        ProductsRepository = new ProductRepository(_context);
        UsersRepository = new UserRepository(_context);
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
