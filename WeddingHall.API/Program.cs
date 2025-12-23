using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.Interfaces;
using WeddingHall.Infrastructure;
using WeddingHall.Infrastructure.Services;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Infrastructure.Repositories;
using AutoMapper;
using WeddingHall.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);
const string FrontendCors = "FrontendCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCors, policy =>
        policy.WithOrigins(
                "http://localhost:5173", "http://localhost:5174",
                "http://127.0.0.1:5173", "http://127.0.0.1:5174",
                "https://localhost:5173", "https://localhost:5174",
                "http://94.130.221.226:5173", "http://localhost:4000",
                "http://localhost:4200", "http://94.130.221.226:8082",
                "http://94.130.221.226:550", "http://94.130.221.226:47001",
                "http://94.130.221.226:8099", "http://94.130.221.226:8099",
                "http://localhost:8100"
            )
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod()
    );
});

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
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IHallServiceService, HallServiceService>();

//builder.Services.AddScoped<IDashboardService, DashboardService>();



//Repository layer 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IHallRepository, HallRepository>();

//Auto-Mapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





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
