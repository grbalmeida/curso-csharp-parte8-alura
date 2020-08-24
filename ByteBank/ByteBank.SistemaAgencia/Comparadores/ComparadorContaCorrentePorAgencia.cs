using ByteBank.Modelos;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            // Retornar negativo quando a instância precede o obj
            // Retornar zero quando nossa instância e obj forem equivalentes
            // Retornar positivo diferente de zero quando a precedência por de obj

            if (x == y)
            {
                return 0;
            }

            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            if (x.Agencia < y.Agencia)
            {
                return -1; // X fica na frente de Y
            }

            if (x.Agencia == y.Agencia)
            {
                return 0; // São equivalentes
            }

            return 1; // Y fica na frente de X

            // Nossas comparações de números inteiros é equivalente
            // ao que já existe no tipo INT
            // return x.Agencia.CompareTo(y.Agencia);
        }
    }
}
