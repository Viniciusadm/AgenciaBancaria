using System;

namespace AgenciaBancaria.Dominio {
    public class Cliente {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string cpf, string rg, Endereco endereco) {
            this.Nome = nome.ValidarString();
            this.CPF = cpf.ValidarString();
            this.RG = rg.ValidarString();
            this.Endereco = endereco ?? throw new Exception("O endereço deve ser informado");
        }
    }
}