using Biblioteca.Api.Common.Api;
using Biblioteca.Core;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Endpoints.Usuarios;

public class GetAllUsuariosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Usuarios: Get All")
            .WithSummary("Recupera todos usuários")
            .WithDescription("Recupera todos usuários")
            .WithOrder(5)
            .Produces<PagedResponse<List<Usuario>?>>();

    private static async Task<IResult> HandleAsync(IUsuarioHandler handler,
                                                    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
                                                    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllUsuariosRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
