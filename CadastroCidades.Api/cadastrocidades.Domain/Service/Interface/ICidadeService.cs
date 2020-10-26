using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using cadastrocidades.Domain.Models;

namespace cadastrocidades.Domain.Service.Interface
{
    public interface ICidadeService
    {
        Task<IEnumerable<Cidade>> ListAsyncCidade();
        Retorno AddCidade(Cidade cidade);
        Cidade GetCidadeNome(string nomeCidade);
        Retorno UpdateCidade(int id, Cidade cidade);
    }
}