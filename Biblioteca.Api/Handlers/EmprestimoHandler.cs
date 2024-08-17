using Biblioteca.Api.Data;
using Biblioteca.Core.Common;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Emprestimos;
using Biblioteca.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Biblioteca.Api.Handlers;

public class EmprestimoHandler(AppDbContext context) : IEmprestimoHandler
{
    public async Task<Response<Emprestimo?>> CreateAsync(CreateEmprestimoRequest request)
    {
        var usuario = await context.Usuarios.FindAsync(request.UsuarioId);
        var livro = await context.Livros.FindAsync(request.LivroId);

        if (usuario == null)
        {
            return new Response<Emprestimo?>(null, 404, "Usuário não encontrado.");
        }

        if (livro == null)
        {
            return new Response<Emprestimo?>(null, 404, "Livro não encontrado.");
        }

        if(usuario.LivrosPegos >= 5)
        {
            return new Response<Emprestimo?>(null, 400, "Usuário já atingiu o limite de 5 livros emprestados.");
        }

        if (livro.Copias <= 0)
        {
            return new Response<Emprestimo?>(null, 400, "Não há cópias disponíveis para empréstimo.");
        }

        try
        {
            var emprestimo = new Emprestimo
            {
                UsuarioId = request.UsuarioId,
                LivroId = request.LivroId,
                DataEmprestimo = request.DataEmprestimo,
                DataDevolucao = request.DataDevolucao
            };

            if(emprestimo is null)
            {
                return new Response<Emprestimo?>(null, 404, "Emprestimo inválido");
            }

            usuario.LivrosPegos++;
            livro.Copias--;

            await context.Emprestimos.AddAsync(emprestimo);
            context.Usuarios.Update(usuario);
            context.Livros.Update(livro);
            await context.SaveChangesAsync();

            return new Response<Emprestimo?>(emprestimo, 201, "Emprestimo criado com sucesso!");
        }

        catch
        {
            return new Response<Emprestimo?>(null, 500, "Não foi possível criar um Emprestimo!");
        }
    }

    public async Task<Response<Emprestimo?>> DeleteAsync(DeleteEmprestimoRequest request)
    {
        try
        {
            var emprestimo = await context.Emprestimos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (emprestimo is null)
            {
                return new Response<Emprestimo?>(null, 404, "Emprestimo inválido");
            }

            context.Emprestimos.Remove(emprestimo);
            await context.SaveChangesAsync();

            return new Response<Emprestimo?>(emprestimo, message: "Emprestimo excluido com sucesso!");
        }
        catch
        {
            return new Response<Emprestimo?>(null, 500, "Não foi possível excluir o emprestimo!");
        }
    }

    public async Task<Response<Emprestimo?>> GetByIdAsync(GetEmprestimoByIdRequest request)
    {
        try
        {
            var emprestimo = await context.Emprestimos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (emprestimo is null)
            {
                return new Response<Emprestimo?>(null, 404, "Emprestimo inválido");
            }

            return new Response<Emprestimo?>(emprestimo);
        }
        catch
        {
            return new Response<Emprestimo?>(null, 500, "Não foi possível retornar um emprestimo!");
        }
    }

    public async Task<PagedResponse<List<Emprestimo>?>> GetByPeriodAsync(GetEmprestimosByPeriodRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirstDay();
            request.EndDate ??= DateTime.Now.GetLastDay();
        }
        catch
        {
            return new PagedResponse<List<Emprestimo>?>(null, 500, "Não foi possível determinar a data de início ou término");
        }

        try
        {
            var query = context
                .Emprestimos
                .AsNoTracking()
                .Where(x => 
                x.DataEmprestimo >= request.StartDate &&
                x.DataDevolucao <= request.EndDate)
                .OrderBy(x => x.DataEmprestimo);

            var transacoes = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Emprestimo>?>(transacoes, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Emprestimo>?>(null, 500, "Não foi possível recuperar os emprestimos!");
        }
        
    }

    public async Task<Response<Emprestimo?>> GetDevolucaoAsync(GetDevolucaoRequest request)
    {
        try
        {
            var emprestimo = await context.Emprestimos.FindAsync(request.Id);

            if (emprestimo == null)
            {
                return new Response<Emprestimo?>(null, 404, "Empréstimo não encontrado.");
            }

            var usuario = await context.Usuarios.FindAsync(emprestimo.UsuarioId);
            var livro = await context.Livros.FindAsync(emprestimo.LivroId);

            if (usuario == null || livro == null)
            {
                return new Response<Emprestimo?>(null, 404, "Usuário ou livro não encontrado.");
            }

            usuario.LivrosPegos--;
            livro.Copias++;

            emprestimo.DataDevolucao = DateTime.Now;

            context.Emprestimos.Update(emprestimo);
            context.Usuarios.Update(usuario);
            context.Livros.Update(livro);
            await context.SaveChangesAsync();

            return new Response<Emprestimo?>(emprestimo, 200, "Devolução registrada com sucesso.");
        }
        catch
        {
            return new Response<Emprestimo?>(null, 500, $"Não foi possível registrar a devolução");
        }
    }

    public async Task<Response<Emprestimo?>> UpdateAsync(UpdateEmprestimoRequest request)
    {
        try
        {
            var emprestimo = await context.Emprestimos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (emprestimo is null)
            {
                return new Response<Emprestimo?>(null, 404, "Emprestimo inválido");
            }

            emprestimo.UsuarioId = request.UsuarioId;
            emprestimo.LivroId = request.LivroId;
            emprestimo.DataEmprestimo = request.DataEmprestimo;
            emprestimo.DataDevolucao = request.DataDevolucao;

            context.Emprestimos.Update(emprestimo);
            await context.SaveChangesAsync();

            return new Response<Emprestimo?>(emprestimo, 201, "Emprestimo atualizado com sucesso!");
        }

        catch
        {
            return new Response<Emprestimo?>(null, 500, "Não foi possível atualizar o emprestimo");
        }
    }
}
