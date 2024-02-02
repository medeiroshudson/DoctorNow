FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["source/DoctorNow.Presentation.WebApi/DoctorNow.Presentation.WebApi.csproj", "source/DoctorNow.Presentation.WebApi/"]
COPY ["source/DoctorNow.Presentation.Common/DoctorNow.Presentation.Common.csproj", "source/DoctorNow.Presentation.Common/"]
COPY ["source/DoctorNow.Infrastructure.CrossCutting/DoctorNow.Infrastructure.CrossCutting.csproj", "source/DoctorNow.Infrastructure.CrossCutting/"]
COPY ["source/DoctorNow.Infrastructure/DoctorNow.Infrastructure.csproj", "source/DoctorNow.Infrastructure/"]
COPY ["source/DoctorNow.Domain.SharedKernel/DoctorNow.Domain.SharedKernel.csproj", "source/DoctorNow.Domain.SharedKernel/"]
COPY ["source/DoctorNow.Domain/DoctorNow.Domain.csproj", "source/DoctorNow.Domain/"]
COPY ["source/DoctorNow.Application/DoctorNow.Application.csproj", "source/DoctorNow.Application/"]
RUN dotnet restore "source/DoctorNow.Presentation.WebApi/DoctorNow.Presentation.WebApi.csproj"
COPY . .
WORKDIR "/src/source/DoctorNow.Presentation.WebApi"
RUN dotnet build "DoctorNow.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DoctorNow.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorNow.Presentation.WebApi.dll"]
