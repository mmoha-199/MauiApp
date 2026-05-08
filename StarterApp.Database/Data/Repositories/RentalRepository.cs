using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;

public class RentalRepository : IRepository<Rental>
{
    private readonly AppDbContext _ctx;
    public RentalRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<Rental> AddAsync(Rental entity)
    {
        _ctx.Rentals.Add(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _ctx.Rentals.FindAsync(id);
        if (e == null) return;
        _ctx.Rentals.Remove(e);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rental>> GetAllAsync() =>
        await _ctx.Rentals
            .Include(r => r.Item)
            .Include(r => r.Renter)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Rental?> GetByIdAsync(int id) =>
        await _ctx.Rentals
            .Include(r => r.Item)
            .Include(r => r.Renter)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(Rental entity)
    {
        _ctx.Rentals.Update(entity);
        await _ctx.SaveChangesAsync();
    }
}
