FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RecruitBoard.Services.Candidates.Api/RecruitBoard.Services.Candidates.Api.csproj", "RecruitBoard.Services.Candidates.Api/"]
RUN dotnet restore "RecruitBoard.Services.Candidates.Api/RecruitBoard.Services.Candidates.Api.csproj"
COPY . .
WORKDIR "/src/RecruitBoard.Services.Candidates.Api"
RUN dotnet build "RecruitBoard.Services.Candidates.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitBoard.Services.Candidates.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitBoard.Services.Candidates.Api.dll"]
