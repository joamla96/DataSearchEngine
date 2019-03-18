FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DataSearchContain.Api/DataSearchContain.Api.csproj", "DataSearchContain.Api/"]
COPY ["DataSearchContain.Application/DataSearchContain.Application.csproj", "DataSearchContain.Application/"]
COPY ["DataSearchContain.Domain/DataSearchContain.Domain.csproj", "DataSearchContain.Domain/"]
COPY ["DataSearchContain.Infrastructure/DataSearchContain.Infrastructure.csproj", "DataSearchContain.Infrastructure/"]
RUN dotnet restore "DataSearchContain.Api/DataSearchContain.Api.csproj"
COPY . .
WORKDIR "/src/DataSearchContain.Api"
RUN dotnet build "DataSearchContain.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataSearchContain.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataSearchContain.Api.dll"]