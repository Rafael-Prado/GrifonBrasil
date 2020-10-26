using cadastrocidades.Domain.Models;

namespace cadastrocidades.Domain.Repositories
{
    public interface IUsuarioReposiory
    {
        Usuario GetUsuario(Usuario usuario);
    }
}