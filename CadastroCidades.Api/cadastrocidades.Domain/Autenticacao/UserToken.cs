﻿using System;

namespace cadastrocidades.Domain.Autenticacao
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}