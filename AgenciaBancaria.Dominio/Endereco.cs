namespace AgenciaBancaria.Dominio {
    public class Endereco {
        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    
        public Endereco(string logradouro, string cep, string cidade, string estado) {
            this.Logradouro = logradouro.ValidarString();
            this.CEP = cep.ValidarString();
            this.Cidade = cidade.ValidarString();
            this.Estado = estado.ValidarString();
        }
    }
}