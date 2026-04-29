using System.Collections.Generic;
using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;


public class ItemService
{
    private readonly ItemRepository _repository;

    public ItemService(ItemRepository repository)
    {
        _repository = repository;
    }

    public void AddItem(string name, string description)
    {
        var item = new Item
        {
            Name = name,
            Description = description,
            IsAvailable = true
        };

        _repository.Add(item);
    }

    public bool CheckAvailability(int itemId)
    {
        var item = _repository.GetById(itemId);
        return item?.IsAvailable ?? false;
    }

    public List<Item> GetItems()
    {
        return _repository.GetAll();
    }
}