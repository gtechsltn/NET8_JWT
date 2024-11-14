using JwtExamples.Business;
using JwtExamples.Infrastructure;
using JwtExamples.MinimalApi.Extensions;
using JwtExamples.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenAuth();

builder.Services
    .AddEndpoints()
    .AddBusiness()
    .AddDatabase(builder.Configuration)
    .AddAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();

app.MapEndpoints();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();