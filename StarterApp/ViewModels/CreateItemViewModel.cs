using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;

namespace StarterApp.ViewModels;

public partial class CreateItemViewModel : ObservableObject
{
    private readonly ItemRepository _repo;
    [ObservableProperty] string name = "";
    [ObservableProperty] string? description;
    [ObservableProperty] decimal pricePerDay;
    [ObservableProperty] string category = "";

    public CreateItemViewModel(ItemRepository repo) => _repo = repo;

    [RelayCommand]
    private async Task SaveAsync()
    {
        var item = new Item
        {
            Name = Name,
            Description = Description,
            PricePerDay = PricePerDay,
            Category = Category
        };
        await _repo.AddAsync(item);
        await Shell.Current.GoToAsync("..");
    }
}
