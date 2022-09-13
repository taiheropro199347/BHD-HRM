#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BHD_HRM/BHD_HRM.csproj", "Masa.Blazor.Pro/"]
RUN dotnet restore "BHD_HRM/BHD_HRM.csproj"
COPY . .
WORKDIR "/src/BHD_HRM"
RUN dotnet build "BHD_HRM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BHD_HRM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BHD_HRM.dll"]
