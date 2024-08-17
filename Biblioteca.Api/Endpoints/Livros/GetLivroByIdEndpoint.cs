using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Livros;

public class GetLivroByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Livros: Get By Id")
            .WithSummary("Recupera um livro")
            .WithDescription("Recupera um livro")
            .WithOrder(4)
            .Produces<Response<Livro?>>();

    private static async Task<IResult> HandleAsync(ILivroHandler handler, long id)
    {
        var request = new GetLivroByIdRequest { Id = id };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
