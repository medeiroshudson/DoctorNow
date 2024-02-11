# To-Do

## Architecture Level
- [X] Domain Driven Design Architecture;
- [X] Options Pattern for Entity Framework Configuration;
- [X] Implementing Result Pattern;
- [X] Type mapping engine - AutoMapper? Mapperly?;
- [ ] Global Error Handling;
- [ ] Implementing Validation Engine;
- [ ] Refactoring Mediator Pattern - implement my own "MediatR";
- [ ] Implementing Repository Caching Decorator with Redis;
- [ ] Implementing Serilog for logging;
- [ ] Automated Tests for Application Architecture;
- [ ] Automated Tests for Business Logic;
- [ ] Move Persistence logic to own class library (DoctorNow.Infrastructure.Persistence);

## Features Level
- [X] HealthCheck endpoint;
- [ ] Api Authentication;
- [ ] Api Authorization;
- [ ] Api Filtering, Sorting and Pagination;

# EF Core Commands

## Add Migration
```
dotnet ef migrations add MIGRATION_NAME -p .\source\DoctorNow.Infrastructure\ -s .\source\DoctorNow.Presentation.WebApi\
```

## Update Database
```
dotnet ef database update -p .\source\DoctorNow.Infrastructure\ -s .\source\DoctorNow.Presentation.WebApi\
```