using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;

namespace cadastrocidades.Domain.Models
{
    public class CidadeFroteira
    {
        [JsonIgnore]
        public int Id { get;  set; }
        public string NomeCidadeFronteira { get;  set; }
        

        [JsonIgnore]
        public virtual int CidadeId { get; set; }
        public virtual Cidade Cidade { get;  set; }
    }
}
