using StarterApp.ViewModels;
namespace StarterApp.Navigation;

/// <summary>
/// Contains all route names used for Shell navigation in the application.
/// Centralizes navigation paths to avoid hardcoded strings across the app.
/// </summary>
public static class Routes
{
    public const string Login = "//login";
    public const string Main = nameof(Views.MainPage);
    public const string Register = nameof(Views.RegisterPage);
    public const string UserList = nameof(Views.UserListPage);
    public const string UserDetail = nameof(Views.UserDetailPage);
    public const string Temp = nameof(Views.TempPage);
    public const string ItemDetail = nameof(Views.ItemDetailPage);
}