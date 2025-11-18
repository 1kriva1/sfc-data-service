#!/bin/sh

./src/API/SFC.Data.Api/entrypoint.Common.sh
dotnet run --project /app/src/API/SFC.Data.Api/SFC.Data.Api.csproj --no-launch-profile