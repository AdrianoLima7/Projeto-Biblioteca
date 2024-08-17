using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Usuarios;

public class GetUsuarioByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Usuarios: Get By Id")
            .WithSummary("Retorna um usuário")
            .WithDescription("Retorna um usuário")
            .WithOrder(4)
            .Produces<Response<Usuario?>>();
    
    private static async Task<IResult> HandleAsync(IUsuarioHandler handler, long id)
    {
        var request = new GetUsuarioByIdRequest
        {
            Id = id
        };

        var response = await handler.GetByIdAsync(request);
        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}
