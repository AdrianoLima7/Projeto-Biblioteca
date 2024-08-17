using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Emprestimos;

public class GetEmprestimoByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Emprestimo: Get By Id")
            .WithSummary("Recupera um empréstimo")
            .WithDescription("Recupera um empréstimo")
            .WithOrder(4)
            .Produces<Response<Emprestimo?>>();

    private static async Task<IResult> HandleAsync(IEmprestimoHandler handler, long id)
    {
        var request = new GetEmprestimoByIdRequest
        {
            Id = id
        };

        var response = await handler.GetByIdAsync(request);
        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}
