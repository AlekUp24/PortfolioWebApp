
using PortfolioWebApp.Domain.Interfaces.Ideas;
using PortfolioWebApp.Infrastructure.Configurations.AutoMapper;
using PortfolioWebApp.Infrastructure.Repositories.Ideas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContextFactory<PortfolioWebApp.Infrastructure.Database.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInnovationIdeasRepository, InnovationIdeasRepository>();
builder.Services.AddAutoMapper(typeof(PortfolioWebAppAutoMapperProfileConfiguration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
