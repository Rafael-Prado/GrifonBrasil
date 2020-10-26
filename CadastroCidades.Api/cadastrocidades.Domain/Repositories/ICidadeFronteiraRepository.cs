using System.Threading.Tasks;
using cadastrocidades.Domain.Models;

namespace cadastrocidades.Domain.Repositories
{
    public interface ICidadeFronteiraRepository
    {
        int AddCidadeFrontira(CidadeFroteira cidadeFronteira);
    }
}