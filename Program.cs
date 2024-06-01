using blazor_gestconf.Components;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using blazor_gestconf.Services;// Assurez-vous que cet espace de noms est correct pour votre projet
using blazor_gestconf.Services.Administrateur;
using blazor_gestconf.Services.Article;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add database context
var connectionString = builder.Configuration.GetConnectionString("blazor_gestconf");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));




builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<ProofReaderService>();
builder.Services.AddScoped<ConferenceService>();
builder.Services.AddScoped<RelectureService>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<CommitteeMemberService>();
builder.Services.AddScoped<IAdministrateurService, AdministrateurService>();
builder.Services.AddScoped<ArticleAuthorService>();
builder.Services.AddScoped<ArticleProofReaderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
