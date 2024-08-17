using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Livros;

public class UpdateLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Livros: Update")
            .WithSummary("Atualiza um livro")
            .WithDescription("Atualiza um livro")
            .WithOrder(2)
            .Produces<Response<Livro?>>();

    private static async Task<IResult> HandleAsync(ILivroHandler handler, UpdateLivroRequest request, long id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
