using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using StarterApp.Database.Models;
using StarterApp.Services;
using StarterApp.ViewModels;


public partial class ItemViewModel : BaseViewModel
{
    private readonly ItemService _service;

    //only modify the collection
    public ObservableCollection<Item> Items { get;} = new();

    //backing fields and property changed
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _description;

    [ObservableProperty]
    private string _searchText;

    
    public ICommand AddItemCommand { get; }
    public ICommand DeleteItemCommand { get; }
    
    public ICommand SearchCommand { get; }

    public ItemViewModel(ItemService service)
    {
        _service = service;
        Title = "Items";

        AddItemCommand = new Command(async () => await AddItem());
        DeleteItemCommand = new Command<Item>(async (item) => await DeleteItem(item));
        SearchCommand = new Command(async () => await Search());
        
    }

    public async Task InitializeAsync()
    {
       Items.Clear();

       var items = await _service.GetItemsAsync();

      foreach (var item in items)
         Items.Add(item);
   }
    //Add and Delete should call the service and then refresh the list. Search should filter the list based on the search text.
    private async Task AddItem()
    {
        if (string.IsNullOrWhiteSpace(Name))
            return;

        await _service.AddItemAsync(Name, Description);

        Name = string.Empty;
        Description = string.Empty;
        await InitializeAsync();
    }
    private async Task DeleteItem(Item item)
    {
        if (item == null)
            return;

        await _service.DeleteItemAsync(item.Id);
        await InitializeAsync();
    }

    private async Task Search()
    {
        Items.Clear();

        var results = string.IsNullOrWhiteSpace(SearchText)
            ? await _service.GetItemsAsync()
            : await _service.SearchItemsAsync(SearchText);

        foreach (var item in results)
            Items.Add(item);
    }


}