using StarterApp.Database.Models;
using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;


namespace StarterApp.Database.Data.Repositories;
public class ItemRepository
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    public ItemRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    public async Task<List<Item>> GetAllAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Items.ToListAsync();
    }
    public async Task AddAsync(Item item)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Items.Add(item);
        await context.SaveChangesAsync();
    }
    public async Task<Item?> GetByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Items.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        //var item = await GetByIdAsync(id);
        var item = await context.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (item != null)
        {
            context.Items.Remove(item);
            await context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Item updatedItem)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Items.Update(updatedItem);
        await context.SaveChangesAsync();
    }

    public async Task<List<Item>> SearchAsync(string query)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Items
            .Where(i => i.Name.ToLower().Contains(query.ToLower()))
            .ToListAsync();
    }
}