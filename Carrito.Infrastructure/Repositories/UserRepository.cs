using Carrito.Application.Interfaces.Repository;
using Carrito.Domain.Entities;
using Carrito.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Carrito.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                                 .Include(u => u.Carts)
                                 .ToListAsync();
        }

        public async Task<User> GetByDniAsync(string dni)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Dni == dni);
            return user;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                                 .Include(u => u.Carts)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
