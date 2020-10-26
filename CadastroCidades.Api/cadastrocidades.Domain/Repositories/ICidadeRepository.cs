using System.Collections.Generic;
using System.Threading.Tasks;
using cadastrocidades.Domain.Models;

namespace cadastrocidades.Domain.Repositories
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<Cidade>> ListAsyncCidades();
        int AddAsync(Cidade cidade);
        Cidade FindByIdAsync(int id);

        void Remove(Cidade cidade);
        bool ExisteCidade(string nomeCidade);
        Cidade GetCidadeNome(string nomeCidade);
        int UpdateCidade(Cidade cidadeUpdate);
    }
}