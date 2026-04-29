using StarterApp.Database.Data.Repositories;
namespace StarterApp.Views;

public partial class ItemDetailPage : ContentPage
{
	public ItemDetailPage()
	{
		InitializeComponent();

		var repo = new ItemRepository();
		var service = new ItemService(repo);

		BindingContext = new ItemDetailViewModel(service);
	}
}