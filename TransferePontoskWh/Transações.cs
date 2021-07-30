namespace TransferePontoskWh
{
    public class Transações
    {
        public static bool TransferirEnergia(Base origem, Base destino, decimal quantidade)
        {
            if (origem.SaldoDisponível < quantidade) return false;
            origem.SaldoDisponível -= quantidade;
            destino.SaldoDisponível += quantidade;
            origem.EnergiaTotalTransferida += quantidade;
            destino.EnergiaTotalRecebida += quantidade;
            return true;
        }
    }
}