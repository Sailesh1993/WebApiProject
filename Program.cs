using WebProject.Controllers;
using WebProject.Database;
using WebProject.Middlewares;
using WebProject.Repositories.Abstractions;
using WebProject.Repositories.Implementations;
using WebProject.Services.Abstractions;
using WebProject.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add database into the application
builder.Services.AddDbContext<DatabaseContext>();

// Add services to the container.
builder.Services.AddControllers();

// ADd service for auto dependency injestion
builder.Services.AddScoped<LoggingMiddleware>();
builder.Services.AddScoped<ErrorHandlerMiddleware>();
builder.Services.AddScoped<CounterMiddleware>();


builder.Services.AddScoped<ICounterService, CounterService>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddTransient<ICounterService, CounterService>();
//builder.Services.AddSingleton<ICounterService, CounterService>();

builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();

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

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<CounterMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

//instance of CounterController
/* var counterService = new CounterService();
var counterController = new CounterController(counterService); */