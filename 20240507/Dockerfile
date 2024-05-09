FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["20240507.csproj",""]
RUN dotnet restore "./20240507.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "20240507.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "20240507.csproj" -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","20240507.dll"]