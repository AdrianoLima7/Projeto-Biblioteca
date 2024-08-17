using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Requests.Usuarios;

public class CreateUsuarioRequest : Request
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório.")]
    [MaxLength(255)]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
    public string Email { get; set; } = string.Empty;

    [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve estar em um formato válido.")]
    public DateTime? DataNascimento { get; set; }

    [Required(ErrorMessage = "O número de telefone é obrigatório.")]
    [Phone(ErrorMessage = "O número de telefone informado não é válido.")]
    public string? Telefone { get; set; }

    [Range(0, 5, ErrorMessage = "O usuário pode pegar no máximo 5 livros emprestados.")]
    public int LivrosPegos { get; set; }
}
