FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# JSON dosyalarının bulunduğu dizini konteynere kopyala
COPY Ecommerce.Services.Identity/keys /app/keys

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecommerce.Services.Identity/Ecommerce.Services.Identity.csproj", "Ecommerce.Services.Identity/"]
RUN dotnet restore "Ecommerce.Services.Identity/Ecommerce.Services.Identity.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Services.Identity"
RUN dotnet build "Ecommerce.Services.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ecommerce.Services.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Erişim izni verme
RUN chmod -R 777 /app/keys

ENTRYPOINT ["dotnet", "Ecommerce.Services.Identity.dll"]
