using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Livros;

public class CreateLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Livros: Create")
            .WithSummary("Criar um novo livro")
            .WithDescription("Criar um novo livro")
            .WithOrder(1)
            .Produces<Response<Livro?>>();

    private static async Task<IResult> HandleAsync(ILivroHandler handler, CreateLivroRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/livros/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
