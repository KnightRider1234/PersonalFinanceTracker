using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.API.Data;
using PersonalFinanceTracker.API.Interfaces;
using PersonalFinanceTracker.API.Mappings;
using PersonalFinanceTracker.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=finance.db"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7147")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
