FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecommerce.Services.CouponAPI/Ecommerce.Services.CouponAPI.csproj", "Ecommerce.Services.CouponAPI/"]
RUN dotnet restore "Ecommerce.Services.CouponAPI/Ecommerce.Services.CouponAPI.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Services.CouponAPI"
RUN dotnet build "Ecommerce.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ecommerce.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Services.CouponAPI.dll"]
