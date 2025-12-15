using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.Interfaces;
using WeddingHall.Infrastructure;
using WeddingHall.Infrastructure.Services;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registered Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHallService, HallService>();
builder.Services.AddScoped<ISubHallService, SubHallService>();

//Repository layer 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IHallRepository, HallRepository>();



//builder.Services.AddDbContext<ApplicationDbContext>();


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
