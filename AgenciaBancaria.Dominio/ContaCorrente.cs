using System;
using System.Globalization;
using System.Text;

namespace AgenciaBancaria.Dominio {
    public class ContaCorrente : ContaBancaria {
        public decimal ValorTaxaManutencao { get; private set; }
        public decimal Limite { get; private set; }
        public ContaCorrente(Cliente cliente, decimal limite) : base(cliente) {
            this.ValorTaxaManutencao = 0.05M;
            this.Limite = limite;
        }

        public override void Sacar(decimal valor, string senha) {
            if (this.Senha != senha) throw new Exception("Senha inválida");
            if ((this.Saldo + this.Limite) < valor) throw new Exception("Saldo insuficiente");

            Console.WriteLine($"Saque de {valor.ToString("F2", CultureInfo.InvariantCulture)} realizado com sucesso\n");
            this.Saldo -= valor;

            if (this.Saldo < 0)
                if ((this.Saldo + valor) <= 0)
                    this.Limite -= valor;
                else
                    this.Limite -= valor / 2;
        }

        public override void ConsultarSaldo(string senha) {
            base.ConsultarSaldo(senha);
            Console.WriteLine($"Limite ${this.Limite}\n");
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Número da conta: {this.NumeroConta}-{this.DigitoVerificador}");
            sb.AppendLine($"Dígito verificador: ");
            sb.AppendLine($"Saldo: R${this.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Limite: R${this.Limite.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Situação: {this.Situacao}");
            sb.AppendLine($"Cliente: {this.Cliente.Nome}");
            return sb.ToString();
        }
    }
}