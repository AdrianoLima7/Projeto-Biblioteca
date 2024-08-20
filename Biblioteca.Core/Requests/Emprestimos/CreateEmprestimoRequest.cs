using Biblioteca.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Requests.Emprestimos;

public class CreateEmprestimoRequest : Request
{
    [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
    public long UsuarioId { get; set; }

    [Required(ErrorMessage = "O ID do livro é obrigatório.")]
    public long LivroId { get; set; }

    [Required(ErrorMessage = "A data de empréstimo é obrigatória.")]
    [DataType(DataType.DateTime, ErrorMessage = "A data de empréstimo deve estar em um formato válido.")]
    public DateTime? DataEmprestimo { get; set; }

    [Required(ErrorMessage = "A data de devolução prevista é obrigatória.")]
    [DataType(DataType.DateTime, ErrorMessage = "A data de devolução prevista deve estar em um formato válido.")]
    public DateTime? DataDevolucaoPrevista { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "A data de devolução prevista deve estar em um formato válido.")]
    public DateTime? DataDevolucao { get; set; }

    [Required(ErrorMessage = "Status inválido")]
    public EStatusType Status { get; set; } = EStatusType.Ativo;
}
