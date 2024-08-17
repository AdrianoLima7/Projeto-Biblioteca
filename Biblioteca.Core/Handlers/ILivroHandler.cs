using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Handlers;

public interface ILivroHandler
{
    Task<Response<Livro?>> CreateAsync(CreateLivroRequest request);
    Task<Response<Livro?>> UpdateAsync(UpdateLivroRequest request);
    Task<Response<Livro?>> DeleteAsync(DeleteLivroRequest request);
    Task<Response<Livro?>> GetByIdAsync(GetLivroByIdRequest request);
    Task<PagedResponse<List<Livro>?>> GetAllAsync(GetAllLivrosRequest request);
}
