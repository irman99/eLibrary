# eLibrary
Projekat RS2

user: admin
password: admin123

.NET 6
Visual Studio 2022
Microsoft SQL Server 2019



Docker: https://hub.docker.com/_/microsoft-mssql-server
docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run -e "ACCEPT_EULA=Y" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
 

NUGET: microsoft.aspnetcore.app

DB scaffold:

Scaffold-DbContext "Data Source=.;Initial Catalog=IB190096;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameWorkCore.SqlServer -outputdir Database/Models -context dbIB190096Context -DataAnnotations -Force

EF Scaffolding:
https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=vs

Automapper:
https://code-maze.com/automapper-net-core/

builder.Services.AddAutoMapper(typeof(Program)); 
builder.Services.AddControllersWithViews();





