using System.Collections.ObjectModel;
using System.Windows.Input;
using StarterApp.Database.Models;

public class ItemDetailViewModel : BindableObject
{
    private readonly ItemService _service;

    public ObservableCollection<Item> Items { get; set; } = new();

    public string Name { get; set; }
    public string Description { get; set; }

    public ICommand AddItemCommand { get; }

    public ItemDetailViewModel(ItemService service)
    {
        _service = service;

        AddItemCommand = new Command(AddItem);
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

    private void LoadItems()
    {
        Items.Clear();
        foreach (var item in _service.GetItems())
        {
            Items.Add(item);
        }
    }
}