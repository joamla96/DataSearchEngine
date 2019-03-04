FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["FileManagementAPI/FileManagementAPI.csproj", "FileManagementAPI/"]
RUN dotnet restore "FileManagementAPI/FileManagementAPI.csproj"
COPY . .
WORKDIR "/src/FileManagementAPI"
RUN dotnet build "FileManagementAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FileManagementAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FileManagementAPI.dll"]