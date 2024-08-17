using Biblioteca.Api.Common.Api;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;

namespace Biblioteca.Api.Endpoints.Emprestimos;

public class GetDevolucaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/devolucao/{id}", HandleAsync)
            .WithName("Emprestimos: Get Devolucao")
            .WithSummary("Retorna uma Devolução")
            .WithDescription("Retorna uma Devolução")
            .WithOrder(6)
            .Produces<Response<Emprestimo?>>();

    private static async Task<IResult> HandleAsync(IEmprestimoHandler handler, long id)
    {
        var request = new GetDevolucaoRequest
        {
            Id = id
        };
        
        var result = await handler.GetDevolucaoAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
