using Biblioteca.Api.Common.Api;
using Biblioteca.Core;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Endpoints.Livros;

public class GetAllLivrosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Livros: Get All")
            .WithSummary("Recupera todos os livros")
            .WithDescription("Recupera todos os livros")
            .WithOrder(5)
            .Produces<PagedResponse<List<Livro>?>>();

    private static async Task<IResult> HandleAsync(ILivroHandler handler,
                                                    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
                                                    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllLivrosRequest
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
