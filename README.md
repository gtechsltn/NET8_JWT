# Implement JWT Authentication in .NET Core
https://www.nikolatech.net/blogs/implement-jwt-authentication-in-dotnet

# Tech Stack
+ .NET Core application
+ Clean Architecture
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
+ FluentResults Version 3.16.0" />
+ FluentValidation Version 11.10.0" />
+ FluentValidation.DependencyInjectionExtensions Version 11.10.0" />
+ Mapster Version 7.4.0" />
+ MediatR Version 12.4.1" />
+ Microsoft.EntityFrameworkCore Version 8.0.10" />
+ Microsoft.Extensions.DependencyInjection.Abstractions Version 8.0.2" />

## Controllers
+ <PackageReference Include="Swashbuckle.AspNetCore Version 6.6.2" />

## Domain
+ .NET 8

## Infra
+ Microsoft.AspNetCore.Authentication.JwtBearer Version 8.0.10
+ Microsoft.Extensions.Configuration.Abstractions Version 8.0.0
+ Microsoft.Extensions.Options Version 8.0.2
+ Microsoft.IdentityModel.JsonWebTokens Version 8.2.0

## MinimalApi
+ Microsoft.AspNetCore.Authentication.JwtBearer Version 8.0.10
+ Microsoft.AspNetCore.OpenApi Version 8.0.10
+ Swashbuckle.AspNetCore Version 6.6.2

## Persistence 
+ Microsoft.EntityFrameworkCore.Tools Version 8.0.10
+ Microsoft.Extensions.DependencyInjection Version 8.0.1
+ Microsoft.EntityFrameworkCore Version 8.0.10
+ Microsoft.EntityFrameworkCore.Design Version 8.0.10
+ Npgsql.EntityFrameworkCore.PostgreSQL Version 8.0.10
+ Microsoft.Extensions.Options Version 8.0.2
+ Microsoft.Extensions.Configuration.Abstractions Version 8.0.0

# References
+ https://www.nikolatech.net/blogs/implement-jwt-authentication-in-dotnet
+ https://github.com/Inderjit-fullstack-dev/MediatRCQRSDemo
+ https://github.com/codewithmukesh/dotnet-zero-to-hero
+ https://docs.google.com/document/d/1AvV2LiAw6nUgN8QoPRRhiQO9MenIw0ePr_IdJki6LqE (both API keys and JWT authorization)
+ https://dev.to/mochafreddo/understanding-api-keys-jwt-and-secure-authentication-methods-11af
+ https://stackoverflow.com/questions/72966528/can-api-key-and-jwt-token-be-used-in-the-same-net-6-webapi
