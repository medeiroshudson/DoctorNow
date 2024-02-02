using DoctorNow.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorNow.Presentation.Common.Extensions;

public static class ApplyMigrationsExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        context.Database.Migrate();
    }  
}