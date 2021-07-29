namespace TransferePontoskWh
{
    public class Base
    {
        public Base(string endereço, decimal energiaTotalProduzida = 10.0m, decimal energiaTotalTransferida = 0.0m,
            decimal energiaTotalRecebida = 0.0m)
        {
            Endereço = endereço;
            SaldoDisponivel = energiaTotalProduzida + energiaTotalRecebida - energiaTotalTransferida;
            if (SaldoDisponivel < 0)
            {
                MontanteDívida = decimal.Subtract(0, SaldoDisponivel);
                SaldoDisponivel = 0.0m;
            }

            EnergiaTotalProduzida = energiaTotalProduzida;
            EnergiaTotalTransferida = energiaTotalTransferida;
            EnergiaTotalRecebida = energiaTotalRecebida;
        }

        public string Endereço { get; set; }
        public decimal SaldoDisponivel { get; set; }

        public decimal MontanteDívida { get; set; }
        public decimal EnergiaTotalProduzida { get; set; }
        public decimal EnergiaTotalTransferida { get; set; }
        public decimal EnergiaTotalRecebida { get; set; }

        public bool Transferir(Base destino, decimal quantidade)
        {
            if (SaldoDisponivel < quantidade) return false;
            SaldoDisponivel -= quantidade;
            destino.SaldoDisponivel += quantidade;
            EnergiaTotalTransferida += quantidade;
            destino.EnergiaTotalRecebida += quantidade;
            return true;
        }

        public static bool Transferir(Base origem, Base destino, decimal quantidade)
        {
            if (origem.SaldoDisponivel < quantidade) return false;
            origem.SaldoDisponivel -= quantidade;
            destino.SaldoDisponivel += quantidade;
            origem.EnergiaTotalTransferida += quantidade;
            destino.EnergiaTotalRecebida += quantidade;
            return true;
        }
    }
}