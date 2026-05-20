using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;
using System.Collections.ObjectModel;
using StarterApp.Services;


namespace StarterApp.ViewModels;

public partial class ItemsViewModel : ObservableObject
{
    private readonly ItemRepository _items;
    private readonly INavigationService _navigationService;

    [ObservableProperty] private ObservableCollection<Item> _list = new();
    [ObservableProperty] private bool _isRefreshing;

    public ItemsViewModel(ItemRepository items, INavigationService navigationService)
    {
        _items = items;
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task LoadAsync()
    {
        IsRefreshing = true;
        var all = await _items.GetAllAsync();
        List = new ObservableCollection<Item>(all);
        IsRefreshing = false;
    }
    
    [RelayCommand]
    private async Task CreateItemAsync()
    {
        await _navigationService.NavigateToAsync("CreateItemPage");
        //await Shell.Current.GoToAsync("ItemsPage");
    }

}
