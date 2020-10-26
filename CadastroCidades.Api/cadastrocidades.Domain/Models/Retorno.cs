using System.Collections;
using System.Collections.Generic;

namespace cadastrocidades.Domain.Models
{
    public class Retorno
    {
        public int code { get; set; }
        public string Mensage { get; set; }
        public IEnumerable<Erro> erros { get; set; }
    }
}