using System;

namespace CoreTransferePontoskWh
{
    public class Menu
    {
        public static void Mostrar()
        {
            Console.WriteLine("========= MENU =========");
            Console.WriteLine("[ 1 ] Cadastrar Pessoa Física");
            Console.WriteLine("[ 2 ] Cadastrar Pessoa Jurídica");
            Console.WriteLine("[ 3 ] Cadastrar Base");
            Console.WriteLine("[ 4 ] Listar Pessoas Físicas");
            Console.WriteLine("[ 5 ] Listar Pessoas Jurídicas");
            Console.WriteLine("[ 6 ] Listar Bases");
            Console.WriteLine("[ 7 ] Transferir Base");
            Console.WriteLine("[ 8 ] Transferir Energia");
            Console.WriteLine("=========================");
        }
    }
}