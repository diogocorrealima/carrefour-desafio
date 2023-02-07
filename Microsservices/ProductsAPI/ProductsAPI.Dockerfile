### Estágio 1 - Obter o source e gerar o Build ###
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-builder
WORKDIR /app
COPY . .
ENV ASPNETCORE_ENVIRONMENT CI
RUN dotnet publish ./ProductsAPI.Services.API/ProductsAPI.Services.API.csproj -o /app/publish 

### Estágio 2 - Subir a aplicação através dos binários ###
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
COPY --from=dotnet-builder /app/publish .
RUN ls -al
ENTRYPOINT ["dotnet", "ProductsAPI.Services.API.dll"]