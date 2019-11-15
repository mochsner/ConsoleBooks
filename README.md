---
__Console Books, A CLI-based Reading List__
- __[.NET Core Reference](https://docs.microsoft.com/en-us/dotnet/core/)__ - cross-platform and efficient runtime environment
- __[Google Books API Reference](https://developers.google.com/books/docs/v1/reference)__ - extensive online selection of books

---
## Instructions
* Install .NET Core 2.1+ [here](https://dotnet.microsoft.com/download)
* Clone this repository: `git clone https://github.com/mochsner/ConsoleBooks`
* Navigate into the ConsoleBooks directory on an administrative shell (i.e. bash or powershell) ` cd ./ConsoleBooks`
* Build the project `dotnet build`
* Run the .exe generation command `dotnet publish -c Debug -r win10-x64`
* Create the Database
```powershell
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```
* Navigate further down to find the ConsoleTest.exe, running it:\
```cd .\ConsoleBooks\bin\Debug\netcoreappX.Y\win-10-x64```

## References
* [Markdown-it](https://markdown-it.github.io/)
