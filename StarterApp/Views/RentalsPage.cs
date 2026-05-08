using StarterApp.ViewModels;
namespace StarterApp.Views;
public partial class RentalsPage : ContentPage
{
    private readonly RentalsViewModel _vm;
    public RentalsPage(RentalsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.LoadCommand.Execute(null);
    }
}
