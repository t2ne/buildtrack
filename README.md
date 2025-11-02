## Installing (using PostgreSQL)

CREATE DATABASE buildtrackmvc;

dotnet restore

dotnet ef database update

dotnet build

---

## Running

dotnet watch run

---

## Sources

https://adminlte.io/themes/v4/index.html

https://www.youtube.com/watch?v=e2Ax71aksNI

---

## Extras

brew install dotnet

dotnet tool install --global dotnet-ef

dotnet new mvc

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
