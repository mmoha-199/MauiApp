using StarterApp.ViewModels;
namespace StarterApp.Views;

public partial class ItemPage : TabbedPage
{
	public ItemPage(ItemPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

		
    // This is just for testing without DI. You can remove this and use the constructor above when you have DI set up.
		/*{ var repo = new ItemRepository();
		var service = new ItemService(repo);

		BindingContext = new ItemPageViewModel(service); }*/
	
}