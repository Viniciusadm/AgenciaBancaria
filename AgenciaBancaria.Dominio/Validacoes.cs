using System;

namespace AgenciaBancaria.Dominio {
    public static class Validacoes {
        public static string ValidarString(this string texto) {
            return !string.IsNullOrWhiteSpace(texto) ? texto : throw new Exception("A propriedade deve ser preenchida");
        }
    }
}