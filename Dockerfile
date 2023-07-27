FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
# COPY ["./app/KororoTest.csproj", "./"]
RUN dotnet restore "./app/KororoTest.csproj"
# COPY . .
RUN dotnet build "./app/KororoTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["aspnet","KororoTest.dll"]