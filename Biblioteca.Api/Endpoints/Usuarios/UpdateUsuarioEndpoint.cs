using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Usuarios;

public class UpdateUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Usuarios: Update")
            .WithSummary("Atualiza um usuário")
            .WithDescription("Atualiza um usuário")
            .WithOrder(2)
            .Produces<Response<Usuario?>>();        
    
    private static async Task<IResult> HandleAsync(IUsuarioHandler handler, UpdateUsuarioRequest request, long id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
