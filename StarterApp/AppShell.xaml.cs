using StarterApp.ViewModels;



namespace StarterApp;

public partial class AppShell : Shell
{
	public AppShell(AppShellViewModel viewModel)
	{	
		BindingContext = viewModel;
		InitializeComponent();
		/* Register routes for DI resolution
        Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
        Routing.RegisterRoute(nameof(RentalsPage), typeof(RentalsPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));*/
		Loaded += async (s, e) =>
        {
            await GoToAsync("//Items");
        };

	}
}
