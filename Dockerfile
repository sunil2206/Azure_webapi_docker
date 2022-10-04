#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Azure_CICD_WebApi/Azure_CICD_WebApi.csproj", "Azure_CICD_WebApi/"]
RUN dotnet restore "Azure_CICD_WebApi/Azure_CICD_WebApi.csproj"
COPY . .
WORKDIR "/src/Azure_CICD_WebApi"
RUN dotnet build "Azure_CICD_WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Azure_CICD_WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Azure_CICD_WebApi.dll"]
