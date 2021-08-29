#!/bin/sh
dotnet clean
rm -rf ./*/bin/ # .NET binaries
rm -rf {.paket,packages,paket-files,paket.lock} # Paket
rm -rf Client/NodeJs/{node_modules,package-lock.json} # Node