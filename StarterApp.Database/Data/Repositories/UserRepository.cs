using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly AppDbContext _ctx;
    public UserRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<User> AddAsync(User entity)
    {
        _ctx.Users.Add(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var u = await _ctx.Users.FindAsync(id);
        if (u == null) return;
        _ctx.Users.Remove(u);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _ctx.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await _ctx.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(User entity)
    {
        _ctx.Users.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email) =>
        await _ctx.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);
}
