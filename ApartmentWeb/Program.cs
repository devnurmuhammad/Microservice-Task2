using Apartment.Application.Services.Persons;
using Apartment.Infrastructure.Data;
using Apartment.Infrastructure.Repositories.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
// This line should be added before making the SQL connection

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnotherConnectionString"));
     options.UseSqlServer(builder.Configuration.GetConnectionString("AnotherConnectionString"), options =>
      {
          options.EnableRetryOnFailure(); // Add this line to enable retry on failure
      });
});
   

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
