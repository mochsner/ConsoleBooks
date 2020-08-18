---
__Console Books, A CLI-based Reading List__
- __[.NET Core Reference](https://docs.microsoft.com/en-us/dotnet/core/)__ - cross-platform and efficient runtime environment
- __[Google Books API Reference](https://developers.google.com/books/docs/v1/reference)__ - extensive online selection of books

---
## Instructions
* Install .NET Core 2.1+ [here](https://dotnet.microsoft.com/download)
* Clone this repository: `git clone https://github.com/mochsner/ConsoleBooks`
* Navigate into the ConsoleBooks directory on an administrative shell (i.e. bash or powershell) ` cd ./ConsoleBooks`
* Run the .exe generation command `dotnet publish -c Debug -r win10-x64`
* Create the Database
```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```
## Cleanup / Rebuild for DB Updates`
```bash
# Clean the database migration
# See Docs for more info on migrations: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
dotnet ef migrations list
dotnet ef migrations remove
```

## Compile an .exe using the runtime
TODO

## Run without SDK or Runtime
* Navigate further down to find the ConsoleTest.exe, running it:\
```cd .\ConsoleBooks\bin\Debug\netcoreappX.Y\win-10-x64```

## References
* [Markdown-it](https://markdown-it.github.io/)
