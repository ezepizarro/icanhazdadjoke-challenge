# I can haz dad joke - challenge
An api to search and get random jokes.  
A web to display and search jokes.


## Stack
- .Net Core 2.2.
- SignalR Core.
- Angular 8 SPA
- Clean architecture based on [CleanArchitecture](https://github.com/ardalis/CleanArchitecture).
- Units testing.
- Moq.
- Automapper
- Global exception handler Middleware
- Swagger using NSwag.
- Azure App Services - [ICanHazDadJoke API](https://ichdadjokeapi.azurewebsites.net/swagger)  
- Azure Storage - [ICanHazDadJoke Web](https://ichdadjoketeststorage.z19.web.core.windows.net/)  

## Overview
|API|Description|
|--|--|
|GET /api/Jokes  | Get a random joke
|GET /api/Search | Get a list of jokes by term 

### Using Azure Sandbox & Angular site.

[ICanHazDadJoke API](https://ichdadjokeapi.azurewebsites.net/swagger)     
[ICanHazDadJoke Web](https://ichdadjoketeststorage.z19.web.core.windows.net/)