using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class ItemDetailPage : ContentPage
{
    private readonly ItemDetailViewModel _viewModel;

    public ItemDetailPage(ItemDetailViewModel viewModel, int itemId)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;

        LoadItem(itemId);
    }

    private async void LoadItem(int itemId)
    {
        await _viewModel.LoadItemByIdAsync(itemId);
    }
}