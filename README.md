# To-Do

## Architecture Level
- [X] Domain Driven Design Architecture;
- [X] Options Pattern for Entity Framework Configuration;
- [X] Implementing Result Pattern;
- [X] Type mapping engine - AutoMapper? Mapperly?;
- [ ] Implementing Validation Engine;
- [ ] Implementing EF Interceptors instead direct logic in context
- [ ] Refactoring Mediator Pattern - implement my own "MediatR";
- [ ] Implementing Repository Caching Decorator with Redis;
- [ ] Implementing Serilog for logging;
- [ ] Automated Tests for Application Architecture;
- [ ] Automated Tests for Business Logic;
- [ ] Move Persistence logic to own class library (DoctorNow.Infrastructure.Persistence);

## Features - Api
- [X] Global Error Handling;
- [X] HealthCheck endpoint;
- [X] Api Authentication;
- [ ] Api Authorization;
- [ ] Api Filtering, Sorting and Pagination;

## Features - Mobile
- [X] Implement Wireframe Screens;
- [ ] Implement Home Dashboard wireframe;
- [ ] Implement Patients view for Doctor;
- [ ] Implement Settings view;
- [ ] Global Error Handling;
- [ ] Transition between pages;
- [ ] Implement Api server;
- [ ] Stateful pages;
- [ ] EPJ AutoPages - automaic pages declaration;


# EF Commands

## Add Migration
```shell
dotnet ef migrations add --project source\DoctorNow.Infrastructure\DoctorNow.Infrastructure.csproj --startup-project source\DoctorNow.Presentation.WebApi\DoctorNow.Presentation.WebApi.csproj --context DoctorNow.Infrastructure.Persistence.Contexts.AppDbContext --configuration Debug MIGRATION_NAME --output-dir Persistence\Migrations
```

## Update Database
```shell
dotnet ef database update --project source\DoctorNow.Infrastructure\DoctorNow.Infrastructure.csproj --startup-project source\DoctorNow.Presentation.WebApi\DoctorNow.Presentation.WebApi.csproj --context DoctorNow.Infrastructure.Persistence.Contexts.AppDbContextaa
```

## Rollback Last Migration
```shell
ef migrations remove --project source\DoctorNow.Infrastructure\DoctorNow.Infrastructure.csproj --startup-project source\DoctorNow.Presentation.WebApi\DoctorNow.Presentation.WebApi.csproj --context DoctorNow.Infrastructure.Persistence.Contexts.AppDbContext --configuration Debug --force
```