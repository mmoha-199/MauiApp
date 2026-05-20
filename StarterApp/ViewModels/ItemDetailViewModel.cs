using System.Collections.ObjectModel;
using System.Windows.Input;
using StarterApp.Database.Models;
using StarterApp.Database.Data.Repositories;

namespace StarterApp.ViewModels;

public class ItemDetailViewModel : BaseViewModel
{
    private readonly ItemRepository _itemRepository;

    private Item? _selectedItem;

    public Item? SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Item> Items { get; set; } = new();

    public ICommand LoadItemsCommand { get; }

    public ItemDetailViewModel(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;

        LoadItemsCommand = new Command(async () => await LoadItemsAsync());
    }

    public async Task LoadItemsAsync()
    {
        Items.Clear();

        var items = await _itemRepository.GetAllAsync();

        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    public async Task LoadItemByIdAsync(int id)
    {
        SelectedItem = await _itemRepository.GetByIdAsync(id);
    }
}