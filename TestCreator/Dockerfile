FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["TestCreator/TestCreator.csproj", "TestCreator/"]
RUN dotnet restore "TestCreator/TestCreator.csproj"
COPY . .
WORKDIR "/src/TestCreator"
RUN dotnet build "TestCreator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestCreator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestCreator.dll"]