FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["IdentityLesson/IdentityLesson.csproj", "IdentityLesson/"]
RUN dotnet restore "IdentityLesson/IdentityLesson.csproj"
COPY . .
WORKDIR "/src/IdentityLesson"
RUN dotnet build "IdentityLesson.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityLesson.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityLesson.dll"]