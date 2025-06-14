FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG CONFIGURATION=Release
WORKDIR /src

COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY MooWordsWorkers.sln .
COPY Src/Domain/Domain.csproj Src/Domain/
COPY Src/Infrastructure/Infrastructure.csproj Src/Infrastructure/
COPY Src/EmailService/EmailService.csproj Src/EmailService/
COPY Src/NotificationService/NotificationService.csproj Src/NotificationService/
COPY Src/Workers/Workers.csproj Src/Workers/

RUN dotnet restore Src/Workers/Workers.csproj

COPY . .

RUN dotnet publish Src/Workers/Workers.csproj -c $CONFIGURATION -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80

ENTRYPOINT ["dotnet", "MooWordsWorkers.Workers.dll"]