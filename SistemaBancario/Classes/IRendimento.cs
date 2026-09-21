using System;

namespace SistemaBancario.Classes
{
    // Interface que define o contrato para contas que possuem rendimento
    public interface IRendimento
    {
        decimal TaxaRendimento { get; }
        void AplicarRendimento();
    }
}