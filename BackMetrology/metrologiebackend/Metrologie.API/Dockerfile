#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Metrologie.API/Metrologie.API.csproj", "Metrologie.API/"]
RUN dotnet restore "Metrologie.API/Metrologie.API.csproj"
COPY . .
WORKDIR "/src/Metrologie.API"
RUN dotnet build "Metrologie.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Metrologie.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Metrologie.API.dll"]