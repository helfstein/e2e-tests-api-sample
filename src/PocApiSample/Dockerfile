#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PocApiSample/PocApiSample.csproj", "PocApiSample/"]
COPY ["PocApiSample.Domain/PocApiSample.Domain.csproj", "PocApiSample.Domain/"]
RUN dotnet restore "PocApiSample/PocApiSample.csproj"
COPY . .
WORKDIR "/src/PocApiSample"
RUN dotnet build "PocApiSample.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PocApiSample.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "PocApiSample.dll"]
