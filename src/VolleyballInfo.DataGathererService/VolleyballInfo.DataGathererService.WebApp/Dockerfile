FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.App/VolleyballInfo.DataGathererService.App.csproj", "src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.App/"]
RUN dotnet restore "src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.App/VolleyballInfo.DataGathererService.App.csproj"
COPY . .
WORKDIR "/src/src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.App"
RUN dotnet build "VolleyballInfo.DataGathererService.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VolleyballInfo.DataGathererService.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolleyballInfo.DataGathererService.App.dll"]
