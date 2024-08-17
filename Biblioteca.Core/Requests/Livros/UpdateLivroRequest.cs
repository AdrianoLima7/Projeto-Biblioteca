using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Requests.Livros;
 
public class UpdateLivroRequest : Request
{
    public long Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    [MaxLength(200, ErrorMessage = "O título pode ter no máximo 200 caracteres.")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O autor é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O autor pode ter no máximo 100 caracteres.")]
    public string Autor { get; set; } = string.Empty;

    [StringLength(13, ErrorMessage = "O ISBN deve ter 13 caracteres.")]
    public string? ISBN { get; set; }

    public int NumeroCopiasDisponiveis { get; set; }

    [Range(1450, 2100, ErrorMessage = "O ano de publicação deve ser entre 1450 e 2100.")]
    public int AnoPublicacao { get; set; }
}
