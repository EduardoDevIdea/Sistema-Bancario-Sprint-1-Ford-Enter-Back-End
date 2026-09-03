using System;

namespace SistemaBancario.Classes
{
    //Classe abstrata
    public abstract class ContaBancaria
    {

        public string NumeroConta { get; private set; }
        public string Titular { get; private set; }
        public decimal Saldo { get; protected set; }

        //Construtor
        public ContaBancaria(string numeroConta, string titular, decimal saldoInicial)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldoInicial;
        }

        //Métodos virtuais (podem ser sobrescritos pelas classes filhas

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
                return;
            }

            Saldo += valor;
            Console.WriteLine($"Depósito de R${valor:F2} realizado como sucesso!");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
        }

        public virtual bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
                return false;
            }

            if (valor > Saldo)
            {
                Console.WriteLine("Erro: Saldo insuficiente para realizar saque.");
                return false;
            }

            Saldo -= valor;
            Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso!");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            return true;
        }

        //metodo abstrato - obrigatorio para classes filhas implementarem
        public abstract void ExibirInformacoes();

        //metodo para exibir saldo
        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual da conta {NumeroConta}: R${Saldo:F2}");
        }

    }

}