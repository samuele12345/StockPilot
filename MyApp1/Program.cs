using MyApp1.Data;
using MyApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // importare per la connessione al db

var builder = WebApplication.CreateBuilder(args); // inizializza l'istanza della web application

// Carica un file locale opzionale con configurazioni specifiche del PC.
// Qui è il punto più corretto: viene letto prima di registrare il DbContext,
// così ogni sviluppatore può usare la propria connection string senza salvarla su Git.
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura il contesto del database e usa la connection string salvata in appsettings.json.
builder.Services.AddDbContext<MyApp1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddIdentity<UserM, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;

})
    .AddEntityFrameworkStores<MyApp1Context>()
    .AddDefaultTokenProviders();

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    // utilizzabile con https://localhost:7159/Items/Edit/3
    pattern: "{controller=Home}/{action=Index}/{id?}") // ci permette di ricevere un id
    .WithStaticAssets();





app.Run();
