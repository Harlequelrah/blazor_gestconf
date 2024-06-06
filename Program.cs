using blazor_gestconf.Components;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using blazor_gestconf.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<SignInManager<Utilisateur>>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.LoginPath = "/article"; // Définir l'URL de la page de connexion
        options.AccessDeniedPath = "/error"; // Définir l'URL de la page d'erreur d'accès refusé
        options.LogoutPath = "/article"; // Définir l'URL de la page de déconnexion
    });

// Add database context
var connectionString = builder.Configuration.GetConnectionString("blazor_gestconf");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<Utilisateur, IdentityRole<int>>(options =>
{
    // Configure password requirements if needed
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6; // Example requirement
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<AuteurService>();
builder.Services.AddScoped<RelecteurService>();
builder.Services.AddScoped<ConferenceService>();
builder.Services.AddScoped<RelectureService>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<MembreComiteService>();
builder.Services.AddScoped<AdministrateurService>();
builder.Services.AddScoped<ArticleAuteurService>();
builder.Services.AddScoped<ArticleRelecteurService>();

var app = builder.Build();

// Create a scope to obtain the RoleManager service
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();


    // Créer les rôles
    string[] roleNames = { "Administrateur", "Auteur", "MembreComite", "Participant" };

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            // Créer le rôle s'il n'existe pas
            await roleManager.CreateAsync(new IdentityRole<int>(roleName));
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/error", createScopeForErrors: true);
    // app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
// app.UseRouting();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapBlazorHub(); // Configure Blazor Server middleware
//     endpoints.MapFallbackToPage("/login"); // Define default entry point
// });

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
