using Biblioteca.Api.Data;
using Biblioteca.Api.Handlers;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Biblioteca.Api.Common.Api;

public static class BuildExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(ApiConfiguration.ConnectionString); });
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ILivroHandler, LivroHandler>();
        builder.Services.AddTransient<IUsuarioHandler, UsuarioHandler>();
        builder.Services.AddTransient<IEmprestimoHandler, EmprestimoHandler>();
        builder.Services.AddTransient<IEmailService, EmailService>();
    }
}
