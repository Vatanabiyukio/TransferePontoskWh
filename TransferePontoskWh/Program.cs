using System;

namespace TransferePontoskWh
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var esconderijoPsicopato = new Base("Caverna da cachoeira 12", 10.0m, 1.0m, 3.0m);
            esconderijoPsicopato.MontanteDívida = 5.0m;
            Console.WriteLine($"Saldo: {esconderijoPsicopato.SaldoDisponível}");
            Console.WriteLine($"Dívida: {esconderijoPsicopato.MontanteDívida}");
            Console.WriteLine($"Crédito: {esconderijoPsicopato.MontanteCrédito}");
        }
    }
}