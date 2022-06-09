using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RBS.Api.Infrastracture.Extensions;
using RBS.API.Infrastracture.Extensions;
using RBS.API.Infrastracture.Middlewares;
using RBS.Application;
using RBS.Data;
using RBS.PersistenceDB.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>(){ }
                    }
                });
});

builder.Services.AddTokenAuthentication(builder.Configuration);

//Add Services
builder.Services.AddServices(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddData(builder.Configuration);


var app = builder.Build();

var service = app.Services.GetService(typeof(IServiceScopeFactory)) as IServiceScopeFactory;
using (var db = service?.CreateScope().ServiceProvider
    .GetService<RBSDbContext>())
{
    db?.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
