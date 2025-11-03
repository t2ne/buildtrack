# BuildTrackMVC

C# + .NET MVC application using Entity Framework Core for scaffolding and PostgreSQL as the backend database.

GitHub: [https://github.com/t2ne/buildtrack-mvc](https://github.com/t2ne/buildtrack-mvc)

---

## First Steps

Before running the project, make sure you have .NET installed.

* **Mac:** Install via Homebrew:

```bash
brew install dotnet
```

* Or use **Visual Studio Community**.
* The project was developed using **VS Code**, but any IDE supporting .NET works.

You also need the Entity Framework CLI:

```bash
dotnet tool install --global dotnet-ef
```

---

## Installing (Using PostgreSQL)

1. Open your terminal and create the database using `psql`:

```bash
psql -U postgres -c "CREATE DATABASE buildtrackmvc;"
```

> Replace `postgres` with your PostgreSQL username if different.

2. Restore project dependencies:

```bash
dotnet restore
```

3. Apply migrations to create tables in your database:

```bash
dotnet ef database update
```

4. Build the project:

```bash
dotnet build
```

---

## Configuration

The connection string is set in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=buildtrackmvc;Username=postgres;Password=7603;Include Error Detail=true"
}
```

> Update `Username` and `Password` according to your local PostgreSQL credentials.

---

## Running

Run the application using:

```bash
dotnet watch run
```

The app should now be accessible at `https://localhost:5015` (or the port indicated in the console).

---

## Sources & References

* [AdminLTE v4](https://adminlte.io/themes/v4/index.html)
* [YouTube Tutorial](https://www.youtube.com/watch?v=e2Ax71aksNI)

---

## Extras / Useful Commands

```bash
dotnet new mvc
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```
