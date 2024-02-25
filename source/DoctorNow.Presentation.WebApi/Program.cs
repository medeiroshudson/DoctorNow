using DoctorNow.Presentation.Common.Extensions;
using DoctorNow.Presentation.Common.Initializers;
using DoctorNow.Presentation.Common.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.ConfigureAppSettings();
builder.ConfigureAutofacContainer();

builder.Services.AddControllers();
builder.Services.ConfigureSwaggerExplorer()
    .ConfigureHealthChecks()
    .ConfigureJwtAuthentication()
    .ConfigureDbContext(configuration)
    .AddMediatR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHealthChecks("/health");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
