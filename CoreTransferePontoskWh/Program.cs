using System;

namespace CoreTransferePontoskWh
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var esconderijoPsicopato = new Base("Psicopato", "Caverna da cachoeira 12", 10.0m, 1.0m, 3.0m);
            Console.WriteLine($"Capacidade Total: {esconderijoPsicopato.EnergiaTotalProduzida + esconderijoPsicopato.EnergiaTotalRecebida - esconderijoPsicopato.EnergiaTotalTransferida}");
            Console.WriteLine($"Saldo: {esconderijoPsicopato.SaldoDisponível}");
            Console.WriteLine($"Dívida: {esconderijoPsicopato.MontanteDívida}");
            Console.WriteLine($"Crédito: {esconderijoPsicopato.MontanteCrédito}\n");
            var planetaKami = new Base("Psicopato", "Planeta Kami", 10.0m, 1.0m, 3.0m);
            Console.WriteLine($"Capacidade Total: {planetaKami.EnergiaTotalProduzida + planetaKami.EnergiaTotalRecebida - planetaKami.EnergiaTotalTransferida}");
            Console.WriteLine($"Saldo: {planetaKami.SaldoDisponível}");
            Console.WriteLine($"Dívida: {planetaKami.MontanteDívida}");
            Console.WriteLine($"Crédito: {planetaKami.MontanteCrédito}\n");
            Transações.TransferirEnergia();
            // esconderijoPsicopato.EnergiaTotalProduzida = 15;
            // esconderijoPsicopato.MontanteDívida = 18;
            Console.WriteLine($"Capacidade Total: {esconderijoPsicopato.EnergiaTotalProduzida + esconderijoPsicopato.EnergiaTotalRecebida - esconderijoPsicopato.EnergiaTotalTransferida}");
            Console.WriteLine($"Saldo: {esconderijoPsicopato.SaldoDisponível}");
            Console.WriteLine($"Dívida: {esconderijoPsicopato.MontanteDívida}");
            Console.WriteLine($"Crédito: {esconderijoPsicopato.MontanteCrédito}\n");
            Console.WriteLine($"Capacidade Total: {planetaKami.EnergiaTotalProduzida + planetaKami.EnergiaTotalRecebida - planetaKami.EnergiaTotalTransferida}");
            Console.WriteLine($"Saldo: {planetaKami.SaldoDisponível}");
            Console.WriteLine($"Dívida: {planetaKami.MontanteDívida}");
            Console.WriteLine($"Crédito: {planetaKami.MontanteCrédito}\n");
        }
    }
}