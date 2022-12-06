using FitJournal.API;
using FitJournal.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var configurator = ServicesConfigurator.Create(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
configurator.ConfigureServices();
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

//FitJournalDbInitializer.Seed(app);
app.Run();

public partial class Program{

}