using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Api.Endpoints.Usuarios;

public class DeleteUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Usuarios: Delete")
            .WithSummary("Deleta um usuário")
            .WithDescription("Deleta um usuário")
            .WithOrder(3)
            .Produces<Response<Usuario?>>();

    private static async Task<IResult> HandleAsync(IUsuarioHandler handler, long id)
    {
        var request = new DeleteUsuarioRequest
        {
            Id = id
        }; 
            
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
