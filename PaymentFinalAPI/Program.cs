using Microsoft.EntityFrameworkCore;
using PaymentFinalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Nadanie dost�pu do localhosta u�ywanego przez angulara
builder.Services.AddCors(options => options.AddPolicy(name: "UserClientOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyOrigin()     
              .AllowAnyMethod()
              .AllowAnyHeader();
    }));

builder.Services.AddDbContext<PaymentDetailsContext>(
        option => option
        .UseSqlServer(builder.Configuration.GetConnectionString("MyAppConnectionString"))
);

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
