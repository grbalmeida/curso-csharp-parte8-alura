using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            TestaOrderBy();

            Console.ReadLine();
        }

        static void TestaOrderBy()
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(341, 1),
                new ContaCorrente(342, 999),
                new ContaCorrente(340, 4),
                new ContaCorrente(340, 456),
                new ContaCorrente(340, 10),
                new ContaCorrente(290, 123)
            };

            IOrderedEnumerable<ContaCorrente> contasOrdenadasPeloNumero =
                contas.OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadasPeloNumero)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.WriteLine("-------------------------------");

            IOrderedEnumerable<ContaCorrente> contasOrdenadasPelaAgencia =
                contas.OrderBy(conta => conta.Agencia);


            foreach (var conta in contasOrdenadasPelaAgencia)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }

        static void TestaInterfaceIComparer()
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 1),
                new ContaCorrente(340, 99999),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            contas.Sort(new ComparadorContaCorrentePorAgencia());

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }

        static void TestaInterfaceIComparable()
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 1),
                new ContaCorrente(340, 99999),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            contas.Sort();

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }

        static void TestaOrdenacaoListaStrings()
        {
            var nomes = new List<string>
            {
                "Wellington",
                "Guilherme",
                "Luana",
                "Ana"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }

        static void TestaOrdenacaoListaInteiros()
        {
            var idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            idades.AdicionarVarios(45, 89, 12);
            idades.AdicionarVarios(99, -1);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void TestaVar()
        {
            var resultado = SomarVarios(1, 5, 9);

            Console.WriteLine(resultado);

            var conta = new ContaCorrente(344, 56456456);

            conta.Depositar(3443);

            Console.WriteLine(conta);
        }

        static void TestaMetodoExtensaoGenerico()
        {
            List<int> idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            idades.AdicionarVarios(45, 89, 12);
            // ListExtensoes.AdicionarVarios(idades, 45, 89, 12);

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            // listaDeIdades.Adicionar("um texto qualquer");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];

                Console.WriteLine($"Idade no indíce {i}: {idade}");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;

            foreach (int numero in numeros)
            {
                acumulador += numero;
            }

            return acumulador;
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 4456668),
                new ContaCorrente(874, 7781438)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            int[] idades = null;
            idades = new int[6];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;
            idades[5] = 60;

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }
    }
}
