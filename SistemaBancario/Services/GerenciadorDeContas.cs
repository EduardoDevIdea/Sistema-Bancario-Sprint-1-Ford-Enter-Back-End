using System;
using System.Collections.Generic;
using System.Linq;
using SistemaBancario.Classes;

namespace SistemaBancario.Services
{
    public class GerenciadorDeContas
    {
        // Lista para armazenar todas as contas do sistema
        private List<ContaBancaria> contas;

        // Construtor que inicializa a lista
        public GerenciadorDeContas()
        {
            contas = new List<ContaBancaria>();
        }

        // Método para adicionar uma conta à lista
        public void AdicionarConta(ContaBancaria conta)
        {
            contas.Add(conta);
            Console.WriteLine($"Conta {conta.NumeroConta} adicionada com sucesso!");
        }

        // Método para buscar uma conta pelo número
        public ContaBancaria BuscarConta(string numeroConta)
        {
            // Usando LINQ para encontrar a conta
            var conta = contas.FirstOrDefault(c => c.NumeroConta == numeroConta);

            if (conta == null)
            {
                Console.WriteLine($"Conta {numeroConta} não encontrada.");
            }

            return conta;
        }

        // Método para listar todas as contas
        public void ListarContas()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas no sistema.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE CONTAS CADASTRADAS ===");
            Console.WriteLine($"Total de contas: {contas.Count}\n");

            for (int i = 0; i < contas.Count; i++)
            {
                Console.WriteLine($"Conta {i + 1}:");
                contas[i].ExibirInformacoes();
                Console.WriteLine();
            }
        }

        // Método para verificar se uma conta existe
        public bool ContaExiste(string numeroConta)
        {
            return contas.Any(c => c.NumeroConta == numeroConta);
        }

        // Método para obter o número total de contas
        public int ObterTotalContas()
        {
            return contas.Count;
        }

        // Método para limpar a lista de contas (útil para testes)
        public void LimparTodasContas()
        {
            contas.Clear();
            Console.WriteLine("Todas as contas foram removidas do sistema.");
        }
    }
}