using System;

namespace CoreTransferePontoskWh
{
    public class Menu
    {

        private static void Opt()
        {
            Console.WriteLine("============= MENU =============");
            Console.WriteLine("= [ 1 ]  Cadastrar Pessoa Fisica");
            Console.WriteLine("= [ 2 ]  Cadastrar Pessoa Juridica");
            Console.WriteLine("= [ 3 ]  Cadastrar Base");
            Console.WriteLine("= [ 4 ]  Listar Pessoas Fisicas");
            Console.WriteLine("= [ 5 ]  Listar Pessoas Juridicas");
            Console.WriteLine("= [ 6 ]  Listar Bases");
            Console.WriteLine("= [ 7 ]  Transferir Energia");
            Console.WriteLine("= [ 8 ]  Transferir Base");
            Console.WriteLine("= [ 9 ]  Descadastrar Pessoa");
            Console.WriteLine("= [ 10 ] Descadastrar Base");
            Console.WriteLine("= [ h  ] Mostra este menu");
            Console.WriteLine("= [ q  ] Sair");
        }
        public static void Mostrar()
        {
            Menu.Opt();
            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("Opção: ");
                string opção = Console.ReadLine()!.ToLower();
                Console.WriteLine("=================================\n");
                Console.Clear();
                switch (opção)
                {
                    case "1":
                        Operacoes.CadastrarPessoaFisica();
                        break;
                    case "2":
                        Operacoes.CadastrarPessoaJuridica();
                        break;
                    case "3":
                        Operacoes.CadastrarBase();
                        break;
                    case "4":
                        Lista.ListarListaPessoaFisica();
                        break;
                    case "5":
                        Lista.ListarListaPessoaJuridica();
                        break;
                    case "6":
                        Lista.ListarListaBase();
                        break;
                    case "7":
                        Operacoes.TransferirEnergia();
                        break;
                    case "8":
                        Operacoes.TransferirBase();
                        break;
                    case "9":
                        Operacoes.DescadastrarPessoa();
                        break;
                    case "10":
                        Operacoes.DescadastrarBase();
                        break;
                    case "q":
                        Console.WriteLine("[!] Até mais!");
                        break;
                    case "h":
                        Menu.Opt();
                        break;
                    default:
                        Console.WriteLine("[!] Opção inválida!");
                        Menu.Opt();
                        break;
                }
                Console.WriteLine();
                if (opção == "q")
                {
                    break;
                }
            }
        }
    }
}