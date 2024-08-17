using Biblioteca.Api.Data;
using Biblioteca.Core.Handlers;
using Biblioteca.Core.Models;
using Biblioteca.Core.Requests.Usuarios;
using Biblioteca.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Handlers;

public class UsuarioHandler(AppDbContext context) : IUsuarioHandler
{
    public async Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request)
    {
        try
        {
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Telefone = request.Telefone,
                LivrosPegos = request.LivrosPegos
            };

            if (usuario is null)
            {
                return new Response<Usuario?>(null, 404, "Usuario inválido");
            }

            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();

            return new Response<Usuario?>(usuario, 201, "Usuário criado com sucesso!");
        }
        catch
        {
            return new Response<Usuario?>(null, 500, "Não foi possivel criar uma usuário!");
        }
    }

    public async Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request)
    {
        try
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (usuario is null)
            {
                return new Response<Usuario?>(null, 404, "Usuario inválido");
            }

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();

            return new Response<Usuario?>(usuario, message: "Usuário excluído com sucesso!");
        }
        catch
        {
            return new Response<Usuario?>(null, 500, "Não foi possível excluir um usuário!");
        }
    }

    public async Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuariosRequest request)
    {
        try
        {
            var query = context.Usuarios.AsNoTracking();

            var count = await query.CountAsync();

            var usuarios = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            return new PagedResponse<List<Usuario>?>(usuarios, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Usuario>?>(null, 500, "Não foi possível retornar todos usuários!");
        }
    }

    public async Task<Response<Usuario?>> GetByIdAsync(GetUsuarioByIdRequest request)
    {
        try
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (usuario is null)
            {
                return new Response<Usuario?>(null, 404, "Usuario inválido");
            }

            return new Response<Usuario?>(usuario);
        }
        catch
        {
            return new Response<Usuario?>(null, 500, "Não foi possível retornar o usuário!");
        }
        
    }

    public async Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request)
    {
        try
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (usuario is null)
            {
                return new Response<Usuario?>(null, 404, "Usuario inválido");
            }

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.DataNascimento = request.DataNascimento;
            usuario.Telefone = request.Telefone;
            usuario.LivrosPegos = request.LivrosPegos;

            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();

            return new Response<Usuario?>(usuario, 201, "Usuário atualízado com sucesso!");
        }

        catch 
        {
            return new Response<Usuario?>(null, 500, "Não foi possível atualizar o usuário!");
        }
    }
}
