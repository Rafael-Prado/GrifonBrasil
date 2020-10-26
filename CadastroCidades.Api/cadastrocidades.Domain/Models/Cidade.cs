using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace cadastrocidades.Domain.Models
{
    public class Cidade
    {
        [JsonIgnore]
        public int Id { get;  set; }
        public string NomeCidade { get;  set; }
        public int NumeroHabitantes { get; set; }

        public virtual IList<CidadeFroteira> CidadesFronteira { get;  set; }


    }
}
