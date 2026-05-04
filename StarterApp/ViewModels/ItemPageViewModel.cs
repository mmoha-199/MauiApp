using System.Collections.ObjectModel;
using System.Windows.Input;
using StarterApp.Database.Models;

public class ItemPageViewModel : BindableObject
{
    private readonly ItemService _service;

    public ObservableCollection<Item> Items { get; set; } = new();

    public string Name { get; set; }
    public string Description { get; set; }

    public ICommand AddItemCommand { get; }
    public ICommand DeleteItemCommand { get; }
    public string SearchText { get; set; }
    public ICommand SearchCommand { get; }

    public ItemPageViewModel(ItemService service)
    {
        _service = service;

        AddItemCommand = new Command(AddItem);
        //DeleteItemCommand = new Command<Item>(DeleteItem);
        SearchCommand = new Command(Search);
        LoadItems();
    }

    private void AddItem()
    {
        if (string.IsNullOrWhiteSpace(Name))
            return;

        _service.AddItem(Name, Description);

        Name = string.Empty;
        Description = string.Empty;

        LoadItems();
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Description));
    }
      /*private void DeleteItem(Item item)
    {
        if (item == null)
            return;

        _service.DeleteItem(item.Id);
        LoadItems();
    }*/

    private void Search()
    {
        Items.Clear();

        var results = string.IsNullOrWhiteSpace(SearchText)
            ? _service.GetItems()
            : _service.SearchItems(SearchText);

        foreach (var item in results)
            Items.Add(item);
    }

    private void LoadItems()
    {
        Items.Clear();
        foreach (var item in _service.GetItems())
        {
            Items.Add(item);
        }
    }
}