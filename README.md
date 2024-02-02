# EF Core Commands

## Add Migration
```
dotnet ef migrations add MIGRATION_NAME -p .\source\DoctorNow.Infrastructure\ -s .\source\DoctorNow.Presentation.WebApi\
```

## Update Database
```
dotnet ef database update -p .\source\DoctorNow.Infrastructure\ -s .\source\DoctorNow.Presentation.WebApi\
```