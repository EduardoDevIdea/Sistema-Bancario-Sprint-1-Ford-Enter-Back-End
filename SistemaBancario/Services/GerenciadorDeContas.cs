using System;
using SistemaBancario.Classes;
using SistemaBancario.Services;

namespace SistemaBancario
{
    class Program
    {
        // Instância do gerenciador de contas (acessível em todo o programa)
        private static GerenciadorDeContas gerenciador = new GerenciadorDeContas();

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    Console.Clear();
                    ExibirCabecalho();
                    ExibirMenu();

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            CriarConta();
                            break;
                        case "2":
                            RealizarDeposito();
                            break;
                        case "3":
                            RealizarSaque();
                            break;
                        case "4":
                            AplicarRendimentoPoupanca();
                            break;
                        case "5":
                            SolicitarEmprestimoEmpresarial();
                            break;
                        case "6":
                            PagarEmprestimoEmpresarial();
                            break;
                        case "7":
                            ExibirSaldoConta();
                            break;
                        case "8":
                            gerenciador.ListarContas();
                            break;
                        case "9":
                            continuar = false;
                            Console.WriteLine("Obrigado por usar o Sistema Bancário!");
                            Console.WriteLine("Pressione qualquer tecla para sair...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }

                    if (continuar && opcao != "9")
                    {
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // Método para exibir o cabeçalho do sistema
        static void ExibirCabecalho()
        {
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║        SISTEMA BANCÁRIO - v1.0          ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            Console.WriteLine();
        }

        // Método para exibir o menu de opções
        static void ExibirMenu()
        {
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1 - Criar nova conta");
            Console.WriteLine("2 - Realizar depósito");
            Console.WriteLine("3 - Realizar saque");
            Console.WriteLine("4 - Aplicar rendimento (Conta Poupança)");
            Console.WriteLine("5 - Solicitar empréstimo (Conta Empresarial)");
            Console.WriteLine("6 - Pagar empréstimo (Conta Empresarial)");
            Console.WriteLine("7 - Consultar saldo");
            Console.WriteLine("8 - Listar todas as contas");
            Console.WriteLine("9 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
        }

        // Método para criar uma nova conta
        static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("=== CRIAÇÃO DE NOVA CONTA ===\n");

            try
            {
                // Escolher o tipo de conta
                Console.WriteLine("Tipos de conta disponíveis:");
                Console.WriteLine("1 - Conta Corrente");
                Console.WriteLine("2 - Conta Poupança");
                Console.WriteLine("3 - Conta Empresarial");
                Console.Write("Escolha o tipo: ");
                string tipoConta = Console.ReadLine();

                // Dados comuns a todas as contas
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                // Verificar se a conta já existe
                if (gerenciador.ContaExiste(numeroConta))
                {
                    Console.WriteLine("Erro: Já existe uma conta com este número!");
                    return;
                }

                Console.Write("Nome do titular: ");
                string titular = Console.ReadLine();

                Console.Write("Saldo inicial: ");
                decimal saldoInicial = decimal.Parse(Console.ReadLine());

                ContaBancaria novaConta = null;

                // Criar a conta conforme o tipo escolhido
                switch (tipoConta)
                {
                    case "1":
                        novaConta = new ContaCorrente(numeroConta, titular, saldoInicial);
                        Console.WriteLine("Conta Corrente criada com taxa de R$ 2,50 por saque.");
                        break;
                    case "2":
                        novaConta = new ContaPoupanca(numeroConta, titular, saldoInicial);
                        Console.WriteLine("Conta Poupança criada com rendimento de 0,5% ao mês.");
                        break;
                    case "3":
                        novaConta = new ContaEmpresarial(numeroConta, titular, saldoInicial);
                        Console.WriteLine("Conta Empresarial criada com limite de R$ 10.000,00.");
                        break;
                    default:
                        Console.WriteLine("Tipo de conta inválido!");
                        return;
                }

                gerenciador.AdicionarConta(novaConta);
                Console.WriteLine("Conta criada com sucesso!");
                novaConta.ExibirInformacoes();
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite um valor numérico válido para o saldo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar conta: {ex.Message}");
            }
        }

        // Método para realizar depósito
        static void RealizarDeposito()
        {
            Console.Clear();
            Console.WriteLine("=== REALIZAR DEPÓSITO ===\n");

            try
            {
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                var conta = gerenciador.BuscarConta(numeroConta);
                if (conta == null)
                    return;

                Console.Write("Valor do depósito: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                conta.Depositar(valor);
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite um valor numérico válido!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar depósito: {ex.Message}");
            }
        }

        // Método para realizar saque
        static void RealizarSaque()
        {
            Console.Clear();
            Console.WriteLine("=== REALIZAR SAQUE ===\n");

            try
            {
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                var conta = gerenciador.BuscarConta(numeroConta);
                if (conta == null)
                    return;

                Console.Write("Valor do saque: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                conta.Sacar(valor);
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite um valor numérico válido!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar saque: {ex.Message}");
            }
        }

        // Método para aplicar rendimento na poupança
        static void AplicarRendimentoPoupanca()
        {
            Console.Clear();
            Console.WriteLine("=== APLICAR RENDIMENTO (CONTA POUPANÇA) ===\n");

            try
            {
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                var conta = gerenciador.BuscarConta(numeroConta);
                if (conta == null)
                    return;

                // Verificar se é uma conta poupança
                if (conta is ContaPoupanca poupanca)
                {
                    poupanca.AplicarRendimento();
                }
                else
                {
                    Console.WriteLine("Erro: Esta conta não é uma Conta Poupança!");
                    Console.WriteLine($"Tipo da conta: {conta.GetType().Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao aplicar rendimento: {ex.Message}");
            }
        }

        // Método para solicitar empréstimo (Conta Empresarial)
        static void SolicitarEmprestimoEmpresarial()
        {
            Console.Clear();
            Console.WriteLine("=== SOLICITAR EMPRÉSTIMO (CONTA EMPRESARIAL) ===\n");

            try
            {
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                var conta = gerenciador.BuscarConta(numeroConta);
                if (conta == null)
                    return;

                // Verificar se é uma conta empresarial
                if (conta is ContaEmpresarial empresarial)
                {
                    Console.Write("Valor do empréstimo: ");
                    decimal valor = decimal.Parse(Console.ReadLine());

                    empresarial.SolicitarEmprestimo(valor);
                }
                else
                {
                    Console.WriteLine("Erro: Esta conta não é uma Conta Empresarial!");
                    Console.WriteLine($"Tipo da conta: {conta.GetType().Name}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite um valor numérico válido!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao solicitar empréstimo: {ex.Message}");
            }
        }

        // Método para pagar empréstimo (Conta Empresarial)
        static void PagarEmprestimoEmpresarial()
        {
            Console.Clear();
            Console.WriteLine("=== PAGAR EMPRÉSTIMO (CONTA EMPRESARIAL) ===\n");

            try
            {
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                var conta = gerenciador.BuscarConta(numeroConta);
                if (conta == null)
                    return;

                // Verificar se é uma conta empresarial
                if (conta is ContaEmpresarial empresarial)
                {
                    Console.Write("Valor do pagamento: ");
                    decimal valor = decimal.Parse(Console.ReadLine());

                    empresarial.PagarEmprestimo(valor);
                }
                else
                {
                    Console.WriteLine("Erro: Esta conta não é uma Conta Empresarial!");
                    Console.WriteLine($"Tipo da conta: {conta.GetType().Name}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite um valor numérico válido!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao pagar empréstimo: {ex.Message}");
            }
        }

        // Método para exibir saldo de uma conta
        static void ExibirSaldoConta()
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAR SALDO ===\n");

            try
            {
                Console.Write("Número da conta: ");
                string numeroConta = Console.ReadLine();

                var conta = gerenciador.BuscarConta(numeroConta);
                if (conta == null)
                    return;

                Console.WriteLine();
                conta.ExibirInformacoes();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar saldo: {ex.Message}");
            }
        }
    }
}