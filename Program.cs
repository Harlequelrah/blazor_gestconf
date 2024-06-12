using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Components.Account;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using blazor_gestconf.Components;
using blazor_gestconf.Components.Pages;
using blazor_gestconf.Models;
using blazor_gestconf.Services;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddSingleton<IEmailSender<Utilisateur>, IdentityNoOpEmailSender>();



// Configuration de l'authentification
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider,IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.Domain = "localhost"; // Juste le domaine, sans protocole
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie.Path = "/";
    options.SlidingExpiration = true;
}).AddIdentityCookies();


builder.Services.AddAuthorizationCore();

// Connexion à la base de données
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddScoped<SignInManager<Utilisateur>>();
builder.Services.AddScoped<UserManager<Utilisateur>>();

builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddIdentityCore<Utilisateur>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
  .AddRoles<IdentityRole<int>>()
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders()
  .AddSignInManager();

builder.Services.AddScoped<UtilisateurService>();
builder.Services.AddScoped<UniversiteService>();
builder.Services.AddScoped<EntrepriseService>();
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

// Créer les rôles lors de la première exécution
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

    // Créer les rôles
    string[] roleNames = { "Administrateur", "Auteur", "MembreComite", "Participant","Relecteur" };
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

// Configurer le pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // app.UseMigrationsEndPoint(); // Facultatif pour l'initialisation de la base de données
}
else
{
    app.UseExceptionHandler("/Error");
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapAdditionalIdentityEndpoints();
app.Run();
