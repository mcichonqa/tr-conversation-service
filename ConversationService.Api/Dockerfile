FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConversationService.csproj", "."]
RUN dotnet restore "./ConversationService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ConversationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConversationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConversationService.dll"]