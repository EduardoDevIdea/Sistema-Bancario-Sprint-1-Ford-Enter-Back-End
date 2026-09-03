using System;

namespace SistemaBancario.Classes
{
    // ContaPoupanca herda de ContaBancaria
    public class ContaPoupanca : ContaBancaria
    {
        // Propriedade específica da ContaPoupanca
        public decimal TaxaRendimento { get; private set; }

        // Construtor de ContaBancaria
        // A taxa de rendimento já é definida internamente (0,5% = 0.005m)
        public ContaPoupanca(string numeroConta, string titular, decimal saldoInicial)
            : base(numeroConta, titular, saldoInicial)
        {
            // Definindo o rendimento de 0,5% ao mês (0.005 em decimal)
            TaxaRendimento = 0.005m;
        }

        // Método específico da ContaPoupanca para aplicar rendimento
        public void AplicarRendimento()
        {
            decimal rendimento = Saldo * TaxaRendimento;
            Saldo += rendimento;

            Console.WriteLine($"Rendimento de {TaxaRendimento:P2} aplicado!");
            Console.WriteLine($"Valor do rendimento: R${rendimento:F2}");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
        }

        // Sobrescrever para mostrar uma mensagem personalizada
        public override bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
                return false;
            }

            if (valor > Saldo)
            {
                Console.WriteLine("Erro: Saldo insuficiente para realizar o saque.");
                Console.WriteLine($"Saldo disponível: R${Saldo:F2}");
                return false;
            }

            Saldo -= valor;
            Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso!");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            Console.WriteLine("(Conta Poupança não cobra taxa de saque)");
            return true;
        }

        // Implementação obrigatória do método abstrato
        public override void ExibirInformacoes()
        {
            Console.WriteLine("=== INFORMAÇÕES DA CONTA POUPANÇA ===");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: R${Saldo:F2}");
            Console.WriteLine($"Taxa de Rendimento: {TaxaRendimento:P2} ao mês");
            Console.WriteLine("==========================================");
        }
    }
}