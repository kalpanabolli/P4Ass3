#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ass3/Ass3.csproj", "Ass3/"]
RUN dotnet restore "Ass3/Ass3.csproj"
COPY . .
WORKDIR "/src/Ass3"
RUN dotnet build "Ass3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ass3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ass3.dll"]