using System.Threading.Tasks;
using cadastrocidades.Domain.Models;
using cadastrocidades.Domain.Repositories;

namespace cadastrocidades.Repository.Data.Persistencia.Repositories
{
    public class CidadeFronteiraRepository: BaseRepository, ICidadeFronteiraRepository
    {
        public CidadeFronteiraRepository(AppDbContext context) : base(context)
        {
        }

        public int AddCidadeFrontira(CidadeFroteira cidadeFronteira)
        {
            var cidade = _context.CidadesFroteiras.AddAsync(cidadeFronteira);

            return cidade.Result.Entity.Id;
        }
    }
}