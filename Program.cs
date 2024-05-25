using blazor_gestconf.Components;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using blazor_gestconf.Services ;// Assurez-vous que cet espace de noms est correct pour votre projet
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("blazor_gestconf"), new MySqlServerVersion(new Version(8, 0, 29))));





builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<ProofReaderService>();
builder.Services.AddScoped<ConferenceService>();
builder.Services.AddScoped<RelectureService>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<CommitteeMemberService>();
builder.Services.AddScoped<AdministratorService>();
builder.Services.AddScoped<ArticleAuthorService>();
builder.Services.AddScoped<ArticleProofReaderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
