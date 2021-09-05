#!/bin/sh
cd $( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )/..
rm -rf ./*/bin/ # .NET binaries
rm -rf ./{.paket,packages,paket-files} # Paket
rm -rf ./Client/node_modules # Node
rm -rf ./Client/wwwroot/css/{normalize.min.css,tailwind.min.css} # CSS
dotnet paket clear-cache