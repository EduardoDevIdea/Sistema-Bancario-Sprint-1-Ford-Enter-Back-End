using System;

namespace SistemaBancario.Classes
{
    // ContaCorrente herda de ContaBancaria
    public class ContaCorrente : ContaBancaria
    {
        // Propriedade específica da ContaCorrente
        public decimal TaxaSaque { get; private set; }

        // Construtor da classe
        public ContaCorrente(string numeroConta, string titular, decimal saldoInicial, decimal taxaSaque)
            : base(numeroConta, titular, saldoInicial)
        {
            TaxaSaque = 2.50m; //taxa fixa de R$ 2,50
        }

        // Sobrescrevendo o método Sacar da classe pai
        public override bool Sacar(decimal valor)
        {
            // Calcular o valor total do saque (valor + taxa)
            decimal valorTotal = valor + TaxaSaque;

            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
                return false;
            }

            if (valorTotal > Saldo)
            {
                Console.WriteLine($"Erro: Saldo insuficiente para realizar o saque (R${valorTotal:F2} necessário, incluindo taxa de R${TaxaSaque:F2}).");
                Console.WriteLine($"Saldo disponível: R${Saldo:F2}");
                return false;
            }

            // Realizar o saque (subtraindo o valor total)
            Saldo -= valorTotal;
            Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso!");
            Console.WriteLine($"Taxa cobrada: R${TaxaSaque:F2}");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            return true;
        }

        // Implementação obrigatória do método abstrato
        public override void ExibirInformacoes()
        {
            Console.WriteLine("=== INFORMAÇÕES DA CONTA CORRENTE ===");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: R${Saldo:F2}");
            Console.WriteLine($"Taxa por Saque: R${TaxaSaque:F2}");
            Console.WriteLine("========================================");
        }
    }
}