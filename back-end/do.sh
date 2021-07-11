#!/bin/sh

if [[ $1 = "run" ]]; then
  dotnet build
  dotnet run -p $(pwd)/WebApi/OpenOsp.WebApi.csproj

elif [[ $1 = "migration-add" ]]; then
  cd $(pwd)/WebApi/
  dotnet ef migrations add $2 -p ../Data/OpenOsp.Data.csproj

elif [[ $1 = "migration-remove" ]]; then
  cd $(pwd)/WebApi/
  dotnet ef migrations remove $2 -p ../Data/OpenOsp.Data.csproj

elif [[ $1 = "database-update" ]]; then
  dotnet ef database update -p ../Data/OpenOsp.Data.csproj

elif [[ $1 = "database-drop" ]]; then
  dotnet ef database drop -p ../Data/OpenOsp.Data.csproj

fi