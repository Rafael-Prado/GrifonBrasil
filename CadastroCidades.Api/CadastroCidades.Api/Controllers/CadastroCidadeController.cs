using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using cadastrocidades.Domain.Models;
using cadastrocidades.Domain.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCidades.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class CadastroCidadeController : Controller
    {
        private readonly ICidadeService _cidadeService;

        public CadastroCidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        /// <summary>
        /// Pegar todas a cidades
        /// </summary>
        /// <returns>Objetos contendo valores de cidades</returns>
        [HttpGet]
        public async  Task<IEnumerable<Cidade>>ListCidadeAsync()
        {
            var cidades = await _cidadeService.ListAsyncCidade();
            return cidades;
        }

        /// <summary>
        /// Pegar uma cidade
        /// </summary>
        /// /// <param nomeCidade="nomeCidade">Nome da cidade</param>
        /// <returns>Objeto contendo valor de cidade</returns>
        //[Authorize]
        [HttpGet("{nomeCidade}")]
        public Cidade GetNomeCidade(string nomeCidade)
        {
            var cidade =  _cidadeService.GetCidadeNome(nomeCidade);
            return cidade;
        }

        /// <summary>
        /// Altera uma cidade
        /// </summary>
        /// <param id="id">Id da cidade</param>
        /// <returns>Resultado do processamento</returns>
        //[Authorize]
        [HttpPut("{id}")]
        public HttpResponseMessage UpdateCidade(int id, [FromBody] Cidade cidade)
        {
            cidade.Id = id;
            var retorno = _cidadeService.UpdateCidade(id,cidade);
            var JssonString = JsonSerializer.Serialize(retorno);
            return retorno.code == 200 ? new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(retorno.Mensage, System.Text.Encoding.UTF8, "application/json") } :
                new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(retorno.Mensage, System.Text.Encoding.UTF8, "application/json") };

        }

        /// <summary>
        /// Adiciona uma cidade uma cidade
        /// </summary>
        /// <param>Cidade</param>
        /// <returns>Resultado do processamento</returns>
        //[Authorize]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] Cidade cidade)
        {
            var respose = new  HttpResponseMessage();
            var retorno =  _cidadeService.AddCidade(cidade);
            var JssonString = JsonSerializer.Serialize(retorno);
            return retorno.code == 200 ? new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(retorno.Mensage, System.Text.Encoding.UTF8, "application/json") } :
                new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(retorno.Mensage, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}
