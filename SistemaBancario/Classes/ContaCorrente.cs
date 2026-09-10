using System;

namespace SistemaBancario.Classes
{
    public class ContaCorrente : ContaBancaria
    {
        public decimal TaxaSaque { get; private set; }

        // Construtor SEM o parâmetro taxaSaque (valor definido internamente)
        public ContaCorrente(string numeroConta, string titular, decimal saldoInicial)
            : base(numeroConta, titular, saldoInicial)
        {
            TaxaSaque = 2.50m; // Taxa fixa definida pelo desenvolvedor
        }

        public override bool Sacar(decimal valor)
        {
            decimal valorTotal = valor + TaxaSaque;

            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
                return false;
            }

            if (valorTotal > Saldo)
            {
                Console.WriteLine($"Erro: Saldo insuficiente! Saque: R${valor:F2} + Taxa: R${TaxaSaque:F2} = R${valorTotal:F2} necessário.");
                Console.WriteLine($"Saldo disponível: R${Saldo:F2}");
                return false;
            }

            Saldo -= valorTotal;
            Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso!");
            Console.WriteLine($"Taxa cobrada: R${TaxaSaque:F2}");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            return true;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine("\n=== INFORMAÇÕES DA CONTA CORRENTE ===");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: R${Saldo:F2}");
            Console.WriteLine($"Taxa por Saque: R${TaxaSaque:F2}");
            Console.WriteLine("========================================");
        }
    }
}