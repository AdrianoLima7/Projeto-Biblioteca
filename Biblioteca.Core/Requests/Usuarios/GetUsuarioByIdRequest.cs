using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Requests.Usuarios;

public class GetUsuarioByIdRequest : Request
{
    public long Id { get; set; }
}
