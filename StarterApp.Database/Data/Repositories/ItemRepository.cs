using StarterApp.Database.Models;
using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;


namespace StarterApp.Database.Data.Repositories;
public class ItemRepository
{
    private readonly AppDbContext _context;
    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Item> GetAll()
    {
        return _context.Items.ToList();
    } 
    public void Add(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
    }
    public Item? GetById(int id)
    {
        return _context.Items.FirstOrDefault(i => i.Id == id);
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }

    public void Update(Item updatedItem)
    {
        _context.Items.Update(updatedItem);
        _context.SaveChanges();
    
    }

    public List<Item> Search(string query)
    {
        return _context.Items
            .Where(i => i.Name.Contains(query))
            .ToList();
    }
}