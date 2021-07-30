using System;

namespace CoreTransferePontoskWh
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var esconderijoPsicopato = new Base("Caverna da cachoeira 12", 10.0m, 1.0m, 3.0m);
            Console.WriteLine($"Capacidade Total: {esconderijoPsicopato.EnergiaTotalProduzida + esconderijoPsicopato.EnergiaTotalRecebida - esconderijoPsicopato.EnergiaTotalTransferida}");
            Console.WriteLine($"Saldo: {esconderijoPsicopato.SaldoDisponível}");
            Console.WriteLine($"Dívida: {esconderijoPsicopato.MontanteDívida}");
            Console.WriteLine($"Crédito: {esconderijoPsicopato.MontanteCrédito}\n");
            esconderijoPsicopato.EnergiaTotalProduzida = 25.0m;
            esconderijoPsicopato.SaldoDisponível = 20;
            Console.WriteLine($"Capacidade Total: {esconderijoPsicopato.EnergiaTotalProduzida + esconderijoPsicopato.EnergiaTotalRecebida - esconderijoPsicopato.EnergiaTotalTransferida}");
            Console.WriteLine($"Saldo: {esconderijoPsicopato.SaldoDisponível}");
            Console.WriteLine($"Dívida: {esconderijoPsicopato.MontanteDívida}");
            Console.WriteLine($"Crédito: {esconderijoPsicopato.MontanteCrédito}");
        }
    }
}