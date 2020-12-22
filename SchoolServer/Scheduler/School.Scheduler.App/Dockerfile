#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Scheduler/School.Scheduler.App/School.Scheduler.App.csproj", "Scheduler/School.Scheduler.App/"]
RUN dotnet restore "Scheduler/School.Scheduler.App/School.Scheduler.App.csproj"
COPY . .
WORKDIR "/src/Scheduler/School.Scheduler.App"
RUN dotnet build "School.Scheduler.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "School.Scheduler.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School.Scheduler.App.dll"]