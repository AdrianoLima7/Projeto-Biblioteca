using Biblioteca.Api.Common.Api;
using Biblioteca.Api.Endpoints.Emprestimos;
using Biblioteca.Api.Endpoints.Livros;
using Biblioteca.Api.Endpoints.Usuarios;

namespace Biblioteca.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK"});

        endpoints.MapGroup("v1/livros")
            .WithTags("Livros")
            .MapEndpoint<CreateLivroEndpoint>()
            .MapEndpoint<UpdateLivroEndpoint>()
            .MapEndpoint<DeleteLivroEndpoint>()
            .MapEndpoint<GetLivroByIdEndpoint>()
            .MapEndpoint<GetAllLivrosEndpoint>();

        endpoints.MapGroup("v1/usuarios")
            .WithTags("Usuarios")
            .MapEndpoint<CreateUsuarioEndpoint>()
            .MapEndpoint<UpdateUsuarioEndpoint>()
            .MapEndpoint<DeleteUsuarioEndpoint>()
            .MapEndpoint<GetUsuarioByIdEndpoint>()
            .MapEndpoint<GetAllUsuariosEndpoint>();

        endpoints.MapGroup("v1/emprestimos")
            .WithTags("Emprestimos")
            .MapEndpoint<CreateEmprestimoEndpoint>()
            .MapEndpoint<DeleteEmprestimoEndpoint>()
            .MapEndpoint<UpdateEmprestimoEndpoint>()
            .MapEndpoint<GetEmprestimoByIdEndpoint>()
            .MapEndpoint<GetEmprestimosByPeriodEndpoint>()
            .MapEndpoint<GetDevolucaoEndpoint>();
            
    }

    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
