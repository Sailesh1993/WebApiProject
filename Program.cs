using WebProject.Controllers;
using WebProject.Middlewares;
using WebProject.Services.Abstractions;
using WebProject.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// ADd service for auto dependency injestion
builder.Services.AddScoped<LoggingMiddleware>();

builder.Services.AddScoped<ICounterService, CounterService>();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddSingleton<ICounterService, CounterService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly); // look for the mapper profile inside current assembly

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

//instance of CounterController
/* var counterService = new CounterService();
var counterController = new CounterController(counterService); */