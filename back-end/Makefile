run:
	dotnet build
	dotnet run -p ./WebApi/OpenOsp.WebApi.csproj

migration-add:
	cd WebApi/ && dotnet ef migrations add $(name) -p ../Data/OpenOsp.Data.csproj

migration-remove:
	cd WebApi/ && dotnet ef migrations remove $(number) -p ../Data/OpenOsp.Data.csproj

database-update:
	dotnet ef database update -p ./WebApi/OpenOsp.WebApi.csproj

database-drop:
	dotnet ef database drop -p ./WebApi/OpenOsp.WebApi.csproj