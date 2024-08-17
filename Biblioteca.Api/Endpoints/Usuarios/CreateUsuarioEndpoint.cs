using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Usuarios;

public class CreateUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Usuarios: Create")
            .WithSummary("Criar um novo usuário")
            .WithDescription("Criar um novo usuário")
            .WithOrder(1)
            .Produces<Response<Usuario?>>();

    private static async Task<IResult> HandleAsync(IUsuarioHandler handler, CreateUsuarioRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/usuarios/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
