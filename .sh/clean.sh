#!/bin/sh
dotnet clean
rm -rf ./*/bin/ # .NET binaries
rm -rf {.paket,packages,paket-files,paket.lock} # Paket
rm -rf Client/{node_modules,package-lock.json} # Node
rm -rf Client/wwwroot/css/{normalize.min.css,tailwind.min.css} # CSS