#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AssetLibrary.Api/AssetLibrary.Api.csproj", "AssetLibrary.Api/"]
RUN dotnet restore "AssetLibrary.Api/AssetLibrary.Api.csproj"
COPY . .
WORKDIR "/src/AssetLibrary.Api"
RUN dotnet build "AssetLibrary.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssetLibrary.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssetLibrary.Api.dll"]