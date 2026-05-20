using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class ItemsPage : ContentPage
{
	private readonly ItemsViewModel _viewModel;
	public ItemsPage(ItemsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;

		/*BindingContext = App.Current.Handler.MauiContext
            .Services.GetService<ItemPageViewModel>();
		if (_viewModel == null)
            throw new Exception("ItemPageViewModel could not be resolved.");*/
	}
	
	/*protected override async void OnAppearing()
	{
		base.OnAppearing();
		//run this async method, but don’t wait for it to complete before allowing the UI to continue loading
		//await _viewModel.InitializeAsync();
        _viewModel.LoadCommand.Execute(null);
	}*/
	   /* private void OnBrowseClicked(object sender, EventArgs e)
    {
        BrowseView.IsVisible = true;
        AddView.IsVisible = false;
        SearchView.IsVisible = false;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        BrowseView.IsVisible = false;
        AddView.IsVisible = true;
        SearchView.IsVisible = false;
    }

    private void OnSearchClicked(object sender, EventArgs e)
    {
        BrowseView.IsVisible = false;
        AddView.IsVisible = false;
        SearchView.IsVisible = true;
    }*/
}