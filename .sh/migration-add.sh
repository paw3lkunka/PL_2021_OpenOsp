#!/bin/sh
dotnet ef migrations add $1 -p ./Server/OpenOsp.Server.csproj -o ./Server/Data/Migrations