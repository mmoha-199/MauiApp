using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;

namespace StarterApp.ViewModels;

public partial class RentalsViewModel : ObservableObject
{
    private readonly RentalRepository _repo;
    [ObservableProperty] ObservableCollection<Rental> rentals = new();
    [ObservableProperty] bool isRefreshing;

    public RentalsViewModel(RentalRepository repo) => _repo = repo;

    [RelayCommand]
    private async Task LoadAsync()
    {
        IsRefreshing = true;
        var all = await _repo.GetAllAsync();
        Rentals = new ObservableCollection<Rental>(all);
        IsRefreshing = false;
    }
}
