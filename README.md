# Implement JWT Authentication in .NET Core
https://www.nikolatech.net/blogs/implement-jwt-authentication-in-dotnet

# Tech Stack
+ .NET Core application
+ JWT (JSON Web Token)
  + Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
  + .UseAuthentication
  + .UseAuthorization
  + [Authorize]
  + [AllowAnonymous]
+ Swagger
+ PostgreSQL
+ MediatR
+ Mapster
+ FluentValidation
+ FluentResults

## Business
+ <PackageReference Include="FluentResults" Version="3.16.0" />
+ <PackageReference Include="FluentValidation" Version="11.10.0" />
+ <PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="11.10.0" />
+ <PackageReference Include="Mapster" Version="7.4.0" />
+ <PackageReference Include="MediatR" Version="12.4.1" />
+ <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.10" />
+ <PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.2" />

## Controllers
+ <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />

## Domain
+ .NET 8

## Infra
+ <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.10" />
+ <PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="8.0.0" />
+ <PackageReference Include="Microsoft.Extensions.Options" Version="8.0.2" />
+ <PackageReference Include="Microsoft.IdentityModel.JsonWebTokens" Version="8.2.0" />

## MinimalApi
+ <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.10" />
+ <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.10" />
+ <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />

## Persistence 
+ <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.10" />
+ <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.1" />
+ <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.10" />
+ <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.10" />
+ <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.10" />
+ <PackageReference Include="Microsoft.Extensions.Options" Version="8.0.2" />
+ <PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="8.0.0" />

# References
+ https://www.nikolatech.net/blogs/implement-jwt-authentication-in-dotnet
+ https://github.com/Inderjit-fullstack-dev/MediatRCQRSDemo
+ https://github.com/codewithmukesh/dotnet-zero-to-hero
+ https://docs.google.com/document/d/1AvV2LiAw6nUgN8QoPRRhiQO9MenIw0ePr_IdJki6LqE (both API keys and JWT authorization)
+ https://dev.to/mochafreddo/understanding-api-keys-jwt-and-secure-authentication-methods-11af
+ https://stackoverflow.com/questions/72966528/can-api-key-and-jwt-token-be-used-in-the-same-net-6-webapi
