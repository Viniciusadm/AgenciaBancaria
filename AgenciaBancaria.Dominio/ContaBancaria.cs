using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AgenciaBancaria.Dominio {
    public abstract class ContaBancaria {
        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }

        public ContaBancaria(Cliente cliente) {
            Random rdn = new Random();
            this.NumeroConta = rdn.Next(10000, 99999);
            this.DigitoVerificador = rdn.Next(0, 9);
            this.Situacao = SituacaoConta.Criada;

            this.Cliente = cliente ?? throw new Exception("O cliente deve ser informado");
        }

        public void Abrir(string senha) {
            SetarSenha(senha);
            this.Situacao = SituacaoConta.Aberta;
            this.DataAbertura = DateTime.Now;
        }

        private void SetarSenha(string senha) {
            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
                throw new Exception("Senha inválida");
            this.Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha) {
            if (this.Senha != senha) throw new Exception("Senha inválida");
            if (this.Saldo < valor) throw new Exception("Saldo insuficiente");
            Console.WriteLine($"Saque de {valor.ToString("F2", CultureInfo.InvariantCulture)} realizado com sucesso\n");
            this.Saldo -= valor;
        }

        public void Depositar(decimal valor, string senha) {
            if (this.Senha != senha) throw new Exception("Senha inválida");

            Console.WriteLine($"Deposito de {valor.ToString("F2", CultureInfo.InvariantCulture)} realizado com sucesso\n");
            this.Saldo += valor;
        }

        public virtual void ConsultarSaldo(string senha) {
            if (this.Senha != senha) throw new Exception("Senha inválida");
            Console.WriteLine($"Saldo ${this.Saldo}");
        }
    }
}