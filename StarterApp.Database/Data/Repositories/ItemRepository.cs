using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;

public class ItemRepository : IRepository<Item>
{
    private readonly AppDbContext _ctx;
    public ItemRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<Item> AddAsync(Item entity)
    {
        _ctx.Items.Add(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _ctx.Items.FindAsync(id);
        if (e == null) return;
        _ctx.Items.Remove(e);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Item>> GetAllAsync() =>
        await _ctx.Items.AsNoTracking().ToListAsync();

    public async Task<Item?> GetByIdAsync(int id) =>
        await _ctx.Items.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(Item entity)
    {
        _ctx.Items.Update(entity);
        await _ctx.SaveChangesAsync();
    }
}
