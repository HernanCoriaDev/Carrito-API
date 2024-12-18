using Carrito.Application.Interfaces.Repository;
using Carrito.Domain.Entities;
using Carrito.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Carrito.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task DeleteAsync(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetByIdAsync(int cartId)
        {
            return await _context.Carts
                                 .Include(c => c.CartProducts)
                                 .ThenInclude(cp => cp.Product)
                                 .FirstOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task<List<Cart>> GetCartsByUserIdAsync(int userId)
        {
            return await _context.Carts
                                 .Include(c => c.CartProducts)
                                 .ThenInclude(cp => cp.Product)
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
    }
}
