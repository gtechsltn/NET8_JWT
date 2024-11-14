using JwtExamples.Business;
using JwtExamples.ControllerApi.Extensions;
using JwtExamples.Infrastructure;
using JwtExamples.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenAuth();

builder.Services
    .AddBusiness()
    .AddDatabase(builder.Configuration)
    .AddAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();