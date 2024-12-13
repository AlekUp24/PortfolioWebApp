

using PortfolioWebApp.Domain.Interfaces.Ideas;
using PortfolioWebApp.Infrastructure.Repositories.Ideas;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().
    AddInteractiveServerComponents();

// add DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContextFactory<PortfolioWebApp.Infrastructure.Database.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRadzenComponents();

// add Http Client
builder.Services.AddScoped<HttpClient>();

// add Application Dependencies
builder.Services.AddApplication();
// add Infrastructure Dependencies
builder.Services.AddInfrustructure(builder.Configuration.GetSection("PortfolioApi"));

builder.Services.AddScoped<IJokesService, JokesService>();
builder.Services.AddScoped<IIdeaAddService, IdeaAddService>();
builder.Services.AddScoped<IIdeaEditService, IdeaEditService>();
builder.Services.AddScoped<IIdeasShowService, IdeasShowService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

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


app.MapRazorComponents<App>().
    AddInteractiveServerRenderMode();

app.Run();
 