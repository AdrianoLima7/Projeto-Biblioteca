using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Emprestimos;

public class UpdateEmprestimoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Emprestimos: Update")
            .WithSummary("Atualiza um empréstimo")
            .WithDescription("Atualiza um empréstimo")
            .WithOrder(2)
            .Produces<Response<Emprestimo?>>();

    private static async Task<IResult> HandleAsync(IEmprestimoHandler handler, UpdateEmprestimoRequest request, int id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
