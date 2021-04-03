using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario =  ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                         Sacar();
                        break;
                    case "5":
                         Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
                Conta minhaConta = new Conta(tipoConta: TipoConta.PessoaFisica, saldo: 1000, credito: 250, nome: "Fabio");

            }
        }

        private static void Depositar()
        {
            Console.WriteLine("informe o numero da conta a ser deposito");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("informe o valor a ser depositado");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numConta].Depositar(valor);
        }

        private static void Sacar()
        {
            Console.WriteLine("informe o numero da conta a ser sacada");
            int numConta = int.Parse( Console.ReadLine());

            Console.WriteLine("informe o valor a ser sacado");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numConta].Sacar(valor);


        }

        private static void Transferir()
        {
            Console.WriteLine("informe o numero da conta a ser origem");
            int numorigem = int.Parse(Console.ReadLine());

            Console.WriteLine("informe o numero da conta a ser destino");
            int numDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("informe o valor a ser a ser transferido");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numorigem].Tranferir(valor, listaContas[numDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para pessoa fisica ou 2 para pessoa juridica");
            int tipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome cliente");
            string nome = Console.ReadLine();

            Console.WriteLine("Saldo inicial");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Credito");
            double credito = double.Parse(Console.ReadLine());

            listaContas.Add(new Conta((TipoConta)tipo, saldo, credito, nome));
        }

        private static void listarContas()
        {

            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
                Console.WriteLine("Nenhuma conta cadastrada");

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine("#{0}", i);
                Console.WriteLine(conta);

            }


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();

            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
