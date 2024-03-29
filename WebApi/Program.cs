using Business;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//------------------------------------------------add
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices(builder.Configuration);


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

//-------------------------------------exception

app.ConfigureCustomExceptionMiddleware();

//-------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();