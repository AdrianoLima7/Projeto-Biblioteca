using Biblioteca.Api.Data;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Livros;
using Biblioteca.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Biblioteca.Api.Handlers;

public class LivroHandler(AppDbContext context) : ILivroHandler
{
    public async Task<Response<Livro?>> CreateAsync(CreateLivroRequest request)
    {
        try
        {
            var livro = new Livro
            {
                Titulo = request.Titulo,
                Autor = request.Autor,
                ISBN = request.ISBN,
                Copias = request.Copias,
                AnoLancamento = request.AnoPublicacao
            };

            if (livro is null)
            {
                return new Response<Livro?>(null, 404, "Livro inválido");
            }

            await context.Livros.AddAsync(livro);
            await context.SaveChangesAsync();

            return new Response<Livro?>(livro, 201, "Livro registrado com sucesso!");
        }
        catch
        {
            return new Response<Livro?>(null, 500, "Não foi possível criar um livro");
        }
    }

    public async Task<Response<Livro?>> DeleteAsync(DeleteLivroRequest request)
    {
        try
        {
            var livro = await context.Livros.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (livro is null)
            {
                return new Response<Livro?>(null, 404, "Livro não encontrado!");
            }

            context.Livros.Remove(livro);
            await context.SaveChangesAsync();

            return new Response<Livro?>(livro ,message: "Livro excluido com sucesso!");
        }
        catch
        {
            return new Response<Livro?>(null, 500, "Não foi possível excluir esse livro");
        }
    }

    public async Task<PagedResponse<List<Livro>?>> GetAllAsync(GetAllLivrosRequest request)
    {
        try
        {
            var query = context.Livros.AsNoTracking();

            var count = await query.CountAsync();

            var livros = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
       

            return new PagedResponse<List<Livro>?>(livros, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Livro>?>(null, 500, "Não foi possivel retornar todos os livros!");
        }
    }

    public async Task<Response<Livro?>> GetByIdAsync(GetLivroByIdRequest request)
    {
        try
        {
            var livro = await context.Livros.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (livro is null)
            {
                return new Response<Livro?>(null, 404, "Livro não encontrado!");
            }

            return new Response<Livro?>(livro);
        }

        catch
        {
            return new Response<Livro?>(null, 500, "Não foi possível retornar o livro!");
        }
    }

    public async Task<Response<Livro?>> UpdateAsync(UpdateLivroRequest request)
    {
        try
        {
            var livro = await context.Livros.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (livro is null)
            {
                return new Response<Livro?>(null, 404, "Livro não encontrado!");
            }

            livro.Titulo = request.Titulo;
            livro.Autor = request.Autor;
            livro.AnoLancamento = request.AnoPublicacao;
            livro.ISBN = request.ISBN;
            livro.Copias = request.NumeroCopiasDisponiveis;

            context.Livros.Update(livro);
            await context.SaveChangesAsync();

            return new Response<Livro?>(livro, 201, "Livro Atualizado com sucesso!");
        }

        catch 
        { 
            return new Response<Livro?>(null, 500, "Não foi possível atualizar um livro!");
        }
    }
}
