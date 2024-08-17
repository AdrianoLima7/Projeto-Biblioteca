using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Requests.Emprestimos;

public class GetEmprestimoByIdRequest : Request
{
    public long Id { get; set; }
}
