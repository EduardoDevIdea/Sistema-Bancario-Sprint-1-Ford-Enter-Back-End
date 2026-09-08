using System;
using System.Linq.Expressions;
using SistemaBancario.Classes;
using SistemaBancario.Services;

namespace SistemaBancario

{
    class Program
    {

        //Instancia de gerenciador de contas (acessivel em todo o programa)
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
                    catch (Exception ex) 
                    {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");

                    Console.ReadKey();
                    }
                }
            }

            //Metodo para exibir o cabeçalho
            static void ExibirCabecalho()
            {
                Console.WriteLine("╔═══════════════════════════════════════════╗");
                Console.WriteLine("║              SISTEMA BANCÁRIO             ║");
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


        static void CriarConta() 
        { 
            Console.Clear();
            Console.WriteLine("== Criação de Nova Conta ===\n");

            try
            {
                // Escolher o tipo de conta
                Console.WriteLine("Tipos de conta disponíveis:");
                Console.WriteLine("1 - Conta Corrente");
                Console.WriteLine("2 - Conta Poupança");
                Console.WriteLine("3 - Conta Empresarial");
                Console.Write("Escolha o tipo: ");

                string tipoConta = Console.ReadLine();

                //verificar se a conta já existe
                if (gerenciador.ContaExiste(numeroConta))
                {
                    Console.WriteLine("Erro: Já existe uma conta com este número!");
                    return;
                }

                Console.WriteLine("Nome do titular:");
                string titular = Console.ReadLine();
            }
        }

    }

    }


}