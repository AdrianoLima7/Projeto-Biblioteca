using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Handlers;

public interface IUsuarioHandler
{
    Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request);
    Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request);
    Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request);
    Task<Response<Usuario?>> GetByIdAsync(GetUsuarioByIdRequest request);
    Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuariosRequest request);
}
