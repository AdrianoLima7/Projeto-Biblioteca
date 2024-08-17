using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Models;

public class Emprestimo
{
    public long Id { get; set; }

    public long UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    public long LivroId { get; set; }
    public Livro? Livro { get; set; }

    public DateTime? DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }

}
