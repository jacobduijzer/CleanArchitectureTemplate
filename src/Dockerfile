FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /src

ARG PROJECT_FILE

COPY . .

RUN dotnet restore ${PROJECT_FILE}
RUN dotnet build -c Release ${PROJECT_FILE}
RUN dotnet publish -c Release -o ./out ${PROJECT_FILE}

FROM base AS final
WORKDIR /app
COPY --from=build /src/out .

ARG PROJECT_DLL
RUN echo "dotnet ${PROJECT_DLL}" > ./entrypoint.sh
ENTRYPOINT ["/bin/sh", "entrypoint.sh"]