FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BidOneAssessment.Api/BidOneAssessment.Api.csproj", "BidOneAssessment.Api/"]
COPY ["BidOneAssessment.Application/BidOneAssessment.Application.csproj", "BidOneAssessment.Application/"]
COPY ["BidOneAssessment.Domain/BidOneAssessment.Domain.csproj", "BidOneAssessment.Domain/"]
COPY ["BidOneAssessment.Core/BidOneAssessment.Core.csproj", "BidOneAssessment.Core/"]
COPY ["BidOneAssessment.QuerySide/BidOneAssessment.QuerySide.csproj", "BidOneAssessment.QuerySide/"]
COPY ["BidOneAssessment.Infrastructure/BidOneAssessment.Infrastructure.csproj", "BidOneAssessment.Infrastructure/"]
RUN dotnet restore "BidOneAssessment.Api/BidOneAssessment.Api.csproj"
COPY . .
WORKDIR "/src/BidOneAssessment.Api"
RUN dotnet build "BidOneAssessment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BidOneAssessment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BidOneAssessment.Api.dll"]
