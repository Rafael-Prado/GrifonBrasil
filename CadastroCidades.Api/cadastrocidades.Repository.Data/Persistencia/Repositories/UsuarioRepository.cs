using System.Linq;
using cadastrocidades.Domain.Models;
using cadastrocidades.Domain.Repositories;

namespace cadastrocidades.Repository.Data.Persistencia.Repositories
{
    public class UsuarioRepository:BaseRepository, IUsuarioReposiory
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public Usuario GetUsuario(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(p => p.UsuarioNome == usuario.UsuarioNome && p.Senha == usuario.Senha);
        }
    }
}