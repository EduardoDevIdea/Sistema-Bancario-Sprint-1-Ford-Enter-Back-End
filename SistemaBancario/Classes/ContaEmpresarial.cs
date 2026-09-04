using System;

namespace SistemaBancario.Classes
{
    // ContaEmpresarial herda de ContaBancaria
    public class ContaEmpresarial : ContaBancaria
    {
        // Propriedades específicas da ContaEmpresarial
        public decimal LimiteEmprestimo { get; private set; }
        public decimal EmprestimoUtilizado { get; private set; }

        // Construtor
        public ContaEmpresarial(string numeroConta, string titular, decimal saldoInicial)
            : base(numeroConta, titular, saldoInicial)
        {
            // Definindo o limite de empréstimo como R$ 10.000,00
            LimiteEmprestimo = 10000.00m;
            EmprestimoUtilizado = 0;
        }

        // Método para solicitar empréstimo
        public bool SolicitarEmprestimo(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do empréstimo deve ser maior que zero.");
                return false;
            }

            // Verificar se o valor solicitado excede o limite disponível
            decimal limiteDisponivel = LimiteEmprestimo - EmprestimoUtilizado;
            if (valor > limiteDisponivel)
            {
                Console.WriteLine($"Erro: Limite de empréstimo insuficiente.");
                Console.WriteLine($"Limite total: R${LimiteEmprestimo:F2}");
                Console.WriteLine($"Limite utilizado: R${EmprestimoUtilizado:F2}");
                Console.WriteLine($"Limite disponível: R${limiteDisponivel:F2}");
                return false;
            }

            // Adicionar o valor ao saldo e atualizar o empréstimo utilizado
            Saldo += valor;
            EmprestimoUtilizado += valor;

            Console.WriteLine($"Empréstimo de R${valor:F2} aprovado e creditado em sua conta!");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            Console.WriteLine($"Empréstimo utilizado: R${EmprestimoUtilizado:F2}");
            Console.WriteLine($"Limite disponível: R${limiteDisponivel - valor:F2}");
            return true;
        }

        // Método para pagar parte do empréstimo
        public bool PagarEmprestimo(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do pagamento deve ser maior que zero.");
                return false;
            }

            if (valor > EmprestimoUtilizado)
            {
                Console.WriteLine($"Erro: Você está tentando pagar mais do que deve.");
                Console.WriteLine($"Valor total do empréstimo utilizado: R${EmprestimoUtilizado:F2}");
                return false;
            }

            if (valor > Saldo)
            {
                Console.WriteLine("Erro: Saldo insuficiente para pagar o empréstimo.");
                Console.WriteLine($"Saldo disponível: R${Saldo:F2}");
                return false;
            }

            // Deduzir do saldo e reduzir o empréstimo utilizado
            Saldo -= valor;
            EmprestimoUtilizado -= valor;

            Console.WriteLine($"Pagamento de R${valor:F2} realizado com sucesso!");
            Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            Console.WriteLine($"Empréstimo restante: R${EmprestimoUtilizado:F2}");
            return true;
        }

        // Sobrescrevendo o método Sacar - não tem taxa, mas permite saldo negativo (usando limite)
        public override bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
                return false;
            }

            // Verifica se o saldo + limite disponível é suficiente
            decimal limiteDisponivel = LimiteEmprestimo - EmprestimoUtilizado;
            decimal saldoTotalDisponivel = Saldo + limiteDisponivel;

            if (valor > saldoTotalDisponivel)
            {
                Console.WriteLine("Erro: Saldo e limite de empréstimo insuficientes.");
                Console.WriteLine($"Saldo disponível: R${Saldo:F2}");
                Console.WriteLine($"Limite disponível: R${limiteDisponivel:F2}");
                Console.WriteLine($"Total disponível: R${saldoTotalDisponivel:F2}");
                return false;
            }

            // Se o saldo for suficiente, usa o saldo
            if (valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso!");
                Console.WriteLine($"Novo saldo: R${Saldo:F2}");
                return true;
            }
            else
            {
                // Se não tiver saldo suficiente, usa o limite de empréstimo
                decimal valorRestante = valor - Saldo;
                Saldo = 0;
                EmprestimoUtilizado += valorRestante;

                Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso!");
                Console.WriteLine($"Usando saldo: R${Saldo:F2}");
                Console.WriteLine($"Usando limite de empréstimo: R${valorRestante:F2}");
                Console.WriteLine($"Novo saldo: R${Saldo:F2}");
                Console.WriteLine($"Empréstimo utilizado: R${EmprestimoUtilizado:F2}");
                return true;
            }
        }

        // Implementação obrigatória do método abstrato
        public override void ExibirInformacoes()
        {
            Console.WriteLine("=== INFORMAÇÕES DA CONTA EMPRESARIAL ===");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: R${Saldo:F2}");
            Console.WriteLine($"Limite de Empréstimo Total: R${LimiteEmprestimo:F2}");
            Console.WriteLine($"Empréstimo Utilizado: R${EmprestimoUtilizado:F2}");
            Console.WriteLine($"Limite Disponível: R${LimiteEmprestimo - EmprestimoUtilizado:F2}");
            Console.WriteLine("============================================");
        }
    }
}