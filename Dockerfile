# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:8.0 AS build
WORKDIR /src
COPY *.sln ./
COPY stat/*.csproj stat/
RUN dotnet restore
COPY . .

# publish
FROM build AS publish
WORKDIR /src/stat
RUN dotnet pack
RUN dotnet tool install stat --add-source .nuget --tool-path /src/tools
# the Global Tool is in /src/tools folder
WORKDIR /src/tools
