using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Livros;

public class DeleteLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Livros : Create")
            .WithSummary("Exclui um livro")
            .WithDescription("Exclui um livro")
            .WithOrder(3)
            .Produces<Response<Livro?>>();
    
    private static async Task<IResult> HandleAsync(ILivroHandler handler, long id)
    {
        var request = new DeleteLivroRequest
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
