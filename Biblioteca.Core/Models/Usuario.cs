using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca.Core.Models;

public class Usuario
{
    public long Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime? DataNascimento { get; set; }

    public string? Telefone { get; set; }

    public int LivrosPegos { get; set; } = 0;

    [JsonIgnore]
    public ICollection<Emprestimo>? Emprestimos { get; set; }
}
