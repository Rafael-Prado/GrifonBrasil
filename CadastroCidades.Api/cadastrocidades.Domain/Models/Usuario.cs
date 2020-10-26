using System;
using System.Collections.Generic;
using System.Text;

namespace cadastrocidades.Domain.Models
{
    public class Usuario
    {
        public int  Id { get; set; }
        public string UsuarioNome { get; set; }
        public string Senha { get; set; }
    }
}
