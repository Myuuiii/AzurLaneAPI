FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AzurLaneAPI.API/AzurLaneAPI.API.csproj", "AzurLaneAPI.API/"]
RUN dotnet restore "AzurLaneAPI.API/AzurLaneAPI.API.csproj"
COPY . .
WORKDIR "/src/AzurLaneAPI.API"
RUN dotnet build "AzurLaneAPI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzurLaneAPI.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzurLaneAPI.API.dll"]
