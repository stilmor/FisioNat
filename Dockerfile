FROM mcr.microsoft.com/dotnet/core/sdk:3.0-disco AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.0-disco AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Raist.dll"]

