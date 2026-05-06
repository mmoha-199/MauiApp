using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;


public class ItemService
{
    private readonly ItemRepository _repository;

    public ItemService(ItemRepository repository)
    {
        _repository = repository;
    }

    public async Task AddItemAsync(string name, string description)
    {
        var item = new Item
        {
            Name = name,
            Description = description,
            IsAvailable = true
        };

        await _repository.AddAsync(item);
    }
        public async Task DeleteItemAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<Item>> SearchItemsAsync(string query)
    {
        var items = await _repository.GetAllAsync();
        return items.Where(i => i.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<bool> CheckAvailabilityAsync(int itemId)
    {
        var item = await _repository.GetByIdAsync(itemId);
        return item?.IsAvailable ?? false;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await _repository.GetAllAsync();
    }
}