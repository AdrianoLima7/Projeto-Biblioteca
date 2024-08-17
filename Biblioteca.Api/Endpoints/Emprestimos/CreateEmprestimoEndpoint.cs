using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Emprestimos;

public class CreateEmprestimoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Emprestimos : Create")
            .WithSummary("Criar um empréstimo")
            .WithDescription("Criar um empréstimo")
            .WithOrder(1)
            .Produces<Response<Emprestimo?>>();

    private static async Task<IResult> HandleAsync(IEmprestimoHandler handler, CreateEmprestimoRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/emprestimos/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
