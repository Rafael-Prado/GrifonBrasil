using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using cadastrocidades.Domain.Models;
using cadastrocidades.Domain.Repositories;
using cadastrocidades.Domain.Service.Interface;

namespace cadastrocidades.Domain.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly ICidadeFronteiraRepository _cidadeFronteiraRepository;

        public CidadeService(ICidadeRepository cidadeRepository, ICidadeFronteiraRepository cidadeFronteiraRepository)
        {
            _cidadeRepository = cidadeRepository;
            _cidadeFronteiraRepository = cidadeFronteiraRepository;
        }

        public async Task<IEnumerable<Cidade>> ListAsyncCidade()
        {
            var cidades = await _cidadeRepository.ListAsyncCidades();
            return cidades;
        }

        public Retorno AddCidade(Cidade cidade)
        {
            var ids = new List<int>();

            if (_cidadeRepository.ExisteCidade(cidade.NomeCidade))
            {
                return new Retorno()
                {
                    code = 403,
                    Mensage = "Já existe essa cidade cadastrada",
                    erros = new List<Erro>()
                };
            }

            if (cidade != null)
            {
                var idcidade = _cidadeRepository.AddAsync(cidade);

                if (idcidade != 0)
                {
                    return new Retorno()
                    {
                        code = 200,
                        Mensage = "Cidade adicionada com sucesso",
                        erros = new List<Erro>()
                    };

                }

                return new Retorno()
                {
                    code = 403,
                    Mensage = "Erro ao adicionar cidade",
                    erros = new List<Erro>()
                };
            }

            return new Retorno()
            {
                code = 403,
                Mensage = "Erro ao adicionar cidade",
                erros = new List<Erro>()
            };
        }

        public Cidade GetCidadeNome(string nomeCidade)
        {
            var cidade = _cidadeRepository.GetCidadeNome(nomeCidade);
            return cidade;
        }

        public Retorno UpdateCidade(int id, Cidade cidade)
        {
            if (cidade == null)
                return new Retorno()
                {
                    code = 403,
                    Mensage = "Erro ao adicionar cidade",
                    erros = new List<Erro>()
                };

                var cidadeUpdate =  _cidadeRepository.FindByIdAsync(id);

                cidadeUpdate.NomeCidade = cidade.NomeCidade;
                cidadeUpdate.NumeroHabitantes = cidade.NumeroHabitantes;

            var idcidade = _cidadeRepository.UpdateCidade(cidadeUpdate);

            if (idcidade != 0)
            {
                return new Retorno()
                {
                    code = 200,
                    Mensage = "Cidade atualizada com sucesso",
                    erros = new List<Erro>()
                };

            }

            return new Retorno()
            {
                code = 403,
                Mensage = "Erro ao adicionar cidade",
                erros = new List<Erro>()
            };
        }
    }
}
