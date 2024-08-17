using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Emprestimos;

public class DeleteEmprestimoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Emprestimos: Delete")
            .WithSummary("Deleta um emprestimo")
            .WithDescription("Deleta um emprestimo")
            .WithOrder(3)
            .Produces<Response<Emprestimo?>>();

    private static async Task<IResult> HandleAsync(IEmprestimoHandler handler, long id)
    {
        var request = new DeleteEmprestimoRequest
        {
            Id = id
        };

        var response = await handler.DeleteAsync(request);
        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}
