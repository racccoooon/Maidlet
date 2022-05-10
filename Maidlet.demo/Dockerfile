FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Maidlet.demo/Maidlet.demo.csproj", "Maidlet.demo/"]
RUN dotnet restore "Maidlet.demo/Maidlet.demo.csproj"
COPY . .
WORKDIR "/src/Maidlet.demo"
RUN dotnet build "Maidlet.demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maidlet.demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maidlet.demo.dll"]
