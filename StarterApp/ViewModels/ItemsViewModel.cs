using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;
using System.Collections.ObjectModel;

namespace StarterApp.ViewModels;

public partial class ItemsViewModel : ObservableObject
{
    private readonly ItemRepository _items;
    [ObservableProperty] private ObservableCollection<Item> _list = new();
    [ObservableProperty] private bool _isRefreshing;

    public ItemsViewModel(ItemRepository items) => _items = items;

    [RelayCommand]
    private async Task LoadAsync()
    {
        IsRefreshing = true;
        var all = await _items.GetAllAsync();
        List = new ObservableCollection<Item>(all);
        IsRefreshing = false;
    }
}
