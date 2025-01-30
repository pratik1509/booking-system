FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Services/Hotel/Hotel.API/Hotel.API.csproj", "src/Services/Hotel/Hotel.API/"]
RUN dotnet restore "src/Services/Hotel/Hotel.API/Hotel.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Hotel/Hotel.API"
RUN dotnet build "Hotel.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Hotel.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotel.API.dll"]
