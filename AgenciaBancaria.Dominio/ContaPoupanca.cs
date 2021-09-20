namespace AgenciaBancaria.Dominio {
    public class ContaPoupanca : ContaBancaria {
        public decimal PercentualRendimento { get; private set; }
        public ContaPoupanca(Cliente cliente) : base(cliente) {
            this.PercentualRendimento = 0.003M;
        }
    }
}