FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.WebApi/VolleyballInfo.DataGathererService.WebApi.csproj", "src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.WebApi/"]
COPY ["src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.Infrastructure/VolleyballInfo.DataGathererService.Infrastructure.csproj", "src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.Infrastructure/"]
COPY ["src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.Application/VolleyballInfo.DataGathererService.Application.csproj", "src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.Application/"]
COPY ["VolleyballInfo.Common/VolleyballInfo.Common/VolleyballInfo.Common.csproj", "VolleyballInfo.Common/VolleyballInfo.Common/"]
RUN dotnet restore "src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.WebApi/VolleyballInfo.DataGathererService.WebApi.csproj"
COPY . .
WORKDIR "/src/src/VolleyballInfo.DataGathererService/VolleyballInfo.DataGathererService.WebApi"
RUN dotnet build "VolleyballInfo.DataGathererService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VolleyballInfo.DataGathererService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolleyballInfo.DataGathererService.WebApi.dll"]
