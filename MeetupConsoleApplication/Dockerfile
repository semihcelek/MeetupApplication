FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MeetupConsoleApplication/MeetupConsoleApplication.csproj", "MeetupConsoleApplication/"]
RUN dotnet restore "MeetupConsoleApplication/MeetupConsoleApplication.csproj"
COPY . .
WORKDIR "/src/MeetupConsoleApplication"
RUN dotnet build "MeetupConsoleApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeetupConsoleApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeetupConsoleApplication.dll"]
