using System;
using AgenciaBancaria.Dominio;

namespace AgenciaBancaria.App {
    class Program {
        static void Main(string[] args){
            try {
                Endereco endereco = new Endereco("Endereço", "99999999", "Cidade", "Estado");
                Cliente cliente = new Cliente("Vinícius", "99999999999", "9999999", endereco);
                ContaCorrente contaCorrente = new ContaCorrente(cliente, 100);
                Console.WriteLine(contaCorrente + "\n");
                string senha = "@AbC1234";
                contaCorrente.Abrir(senha);
                contaCorrente.Depositar(50, senha);
                contaCorrente.ConsultarSaldo(senha);
                contaCorrente.Sacar(100, senha);
                contaCorrente.ConsultarSaldo(senha);
                contaCorrente.Depositar(200, senha);
                contaCorrente.ConsultarSaldo(senha);
                contaCorrente.Sacar(50, senha);
                contaCorrente.ConsultarSaldo(senha);
                contaCorrente.Sacar(100, senha);
                contaCorrente.ConsultarSaldo(senha);
                contaCorrente.Sacar(50, senha);
                contaCorrente.ConsultarSaldo(senha);
                contaCorrente.Depositar(100, senha);;
                contaCorrente.ConsultarSaldo(senha);
            } catch (Exception erro) {
                Console.WriteLine(erro);
            }
        }
    }
}
