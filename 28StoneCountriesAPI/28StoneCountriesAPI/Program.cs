using _28StoneCountriesAPI.Interfaces;
using _28StoneCountriesAPI.Methods;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRefitClient<ICountry>().ConfigureHttpClient(hc => hc.BaseAddress = new Uri("https://restcountries.com"));
builder.Services.AddTransient<ICountryUtility, CountryMethods>();

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
