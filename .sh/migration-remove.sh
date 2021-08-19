#!/bin/sh
dotnet ef migrations remove $1 -p ./Server/OpenOsp.Server.csproj