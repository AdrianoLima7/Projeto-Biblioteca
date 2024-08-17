using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Handlers;

public interface IEmprestimoHandler
{
    Task<Response<Emprestimo?>> CreateAsync(CreateEmprestimoRequest request);
    Task<Response<Emprestimo?>> UpdateAsync(UpdateEmprestimoRequest request);
    Task<Response<Emprestimo?>> DeleteAsync(DeleteEmprestimoRequest request);
    Task<Response<Emprestimo?>> GetByIdAsync(GetEmprestimoByIdRequest request);
    Task<Response<Emprestimo?>> GetDevolucaoAsync(GetDevolucaoRequest request);
    Task<PagedResponse<List<Emprestimo>?>> GetByPeriodAsync(GetEmprestimosByPeriodRequest request);
}
