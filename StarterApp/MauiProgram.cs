using Microsoft.Extensions.Logging;
using StarterApp.ViewModels;
using StarterApp.Database.Data;
using Microsoft.EntityFrameworkCore;
using StarterApp.Views;
using System.Diagnostics;
using StarterApp.Services;
using StarterApp.Database.Data.Repositories;



namespace StarterApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        

        builder.Services.AddDbContextFactory<AppDbContext>();
//Core Services
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
//AppSell and App
        builder.Services.AddSingleton<AppShellViewModel>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<App>();
// Data Repositories
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<ItemRepository>();
        builder.Services.AddScoped<RentalRepository>();
// ViewModels and Pages
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<RegisterPage>();
//UserList and Profile
        builder.Services.AddTransient<UserListViewModel>();
        builder.Services.AddTransient<UserListPage>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<UserDetailPage>();
        builder.Services.AddTransient<UserDetailViewModel>();
//Items
        builder.Services.AddTransient<ItemsPage>();
        builder.Services.AddTransient<ItemsViewModel>();
        builder.Services.AddTransient<CreateItemPage>();
        builder.Services.AddTransient<CreateItemViewModel>();
        builder.Services.AddTransient<ItemDetailViewModel>();
        builder.Services.AddTransient<ItemDetailPage>();
//Rentals
        builder.Services.AddTransient<RentalsPage>();
        builder.Services.AddTransient<RentalsViewModel>();
        builder.Services.AddTransient<CreateItemViewModel>();

        builder.Services.AddSingleton<TempViewModel>();
        builder.Services.AddTransient<TempPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}