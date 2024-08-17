using Biblioteca.Api.Common.Api;
using Biblioteca.Core;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Endpoints.Emprestimos;

public class GetEmprestimosByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Emprestimos: Get By Period")
            .WithSummary("Recuperar todas transações de um periodo")
            .WithDescription("Recuperar todas transações de um periodo")
            .WithOrder(5)
            .Produces<PagedResponse<List<Emprestimo>?>>();

    private static async Task<IResult> HandleAsync(
        IEmprestimoHandler handler,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageSize = Configuration.DefaultPageSize,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber)
    {
        var request = new GetEmprestimosByPeriodRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate,
        };

        var result = await handler.GetByPeriodAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
