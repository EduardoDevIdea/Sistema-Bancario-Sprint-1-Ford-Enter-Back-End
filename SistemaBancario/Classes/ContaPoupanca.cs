using System;

namespace SistemaBancario.Classes
{
    // ContaPoupanca herda de ContaBancaria E implementa IRendimento
    public class ContaPoupanca : ContaBancaria, IRendimento
    {
        // Propriedade que atende o contrato da interface IRendimento
        public decimal TaxaRendimento { get; private set; }

        public ContaPoupanca(string numeroConta, string titular, decimal saldoInicial)
            : base(numeroConta, titular, saldoInicial)
        {
            TaxaRendimento = 0.005m; // 0,5% ao mês
        }

        // Método que atende o contrato da interface IRendimento
        public void AplicarRendimento()
        {
            decimal rendimento = Saldo * TaxaRendimento;
            Saldo += rendimento;

            Console.WriteLine($"Rendimento de {TaxaRendimento:P2} aplicado!");
            Console.WriteLine($"Valor do rendimento: R${rendimento:F2}");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
        }

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