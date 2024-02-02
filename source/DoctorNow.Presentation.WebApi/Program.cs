using DoctorNow.Presentation.Common.Extensions;
using DoctorNow.Presentation.Common.Initializers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.AddAppSettings();
builder.ConfigureAutofacContainer();

builder.Services.AddControllers();
builder.Services.AddSwaggerExplorer()
    .InitializeDbContext(configuration)
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

app.Run();
