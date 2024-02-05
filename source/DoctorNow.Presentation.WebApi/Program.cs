using DoctorNow.Presentation.Common.Extensions;
using DoctorNow.Presentation.Common.Initializers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.ConfigureAppSettings();
builder.ConfigureAutofacContainer();

builder.Services.AddControllers();
builder.Services.AddSwaggerExplorer()
    .InitializeDbContext(configuration)
    .ConfigureHealthChecks()
    .AddMediatR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health");

app.Run();
