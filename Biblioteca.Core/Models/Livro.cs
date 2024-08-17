using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca.Core.Models;

public class Livro
{
    public long Id { get; set; }

    public string Titulo{ get; set; } = string.Empty;

    public string Autor { get; set; } = string.Empty;

    public string? ISBN { get; set; }

    public long Copias { get; set; }

    public int AnoLancamento { get; set; }

    [JsonIgnore]
    public ICollection<Emprestimo>? Emprestimos { get; set; } 

}
