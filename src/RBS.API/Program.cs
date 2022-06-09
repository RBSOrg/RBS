using Microsoft.EntityFrameworkCore;
using RBS.Api.Infrastracture.Extensions;
using RBS.Application;
using RBS.Data;
using RBS.PersistenceDB.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Services
builder.Services.AddServices(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddData(builder.Configuration);


var app = builder.Build();

var service = (IServiceScopeFactory)app.Services.GetService(typeof(IServiceScopeFactory));
using (var db = service.CreateScope().ServiceProvider.GetService<RBSDbContext>())
{
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
