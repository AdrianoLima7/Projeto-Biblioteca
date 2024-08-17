using Biblioteca.Api.Common.Api;
using Biblioteca.Api.Data;
using Biblioteca.Api.Endpoints;
using Biblioteca.Api.Handlers;
using Biblioteca.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDataContexts();
builder.AddDocumentation();
builder.AddServices();



var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.MapEndpoints();

app.Run();
