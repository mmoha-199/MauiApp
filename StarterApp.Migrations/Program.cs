using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Data;


Console.WriteLine("Running migrations...");
using var context = new AppDbContext();
context.Database.Migrate();
//var options = new DbContextOptionsBuilder<AppDbContext>()
    //.UseNpgsql(DbConfig.ConnectionString)
    //.Options;

//using var context = new AppDbContext(options);
//context.Database.Migrate();
Console.WriteLine("Migrations complete.");
