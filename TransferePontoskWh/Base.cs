namespace TransferePontoskWh
{
    public class Base
    {
        private decimal _energiaTotalProduzida;
        private decimal _energiaTotalRecebida;
        private decimal _energiaTotalTransferida;
        private decimal _montanteCrédito;
        private decimal _montanteDívida;
        private decimal _saldoDisponível;

        public Base(string endereço, decimal energiaTotalProduzida = 0.0m, decimal energiaTotalTransferida = 0.0m,
            decimal energiaTotalRecebida = 0.0m)
        {
            Endereço = endereço;
            EnergiaTotalProduzida = energiaTotalProduzida;
            EnergiaTotalTransferida = energiaTotalTransferida;
            EnergiaTotalRecebida = energiaTotalRecebida;
            SaldoDisponível = energiaTotalProduzida + energiaTotalRecebida - energiaTotalTransferida;
            Lista.AdicionarListaBase(this);
        }

        public string Endereço { get; set; }

        public decimal SaldoDisponível
        {
            get => _saldoDisponível;
            set
            {
                _saldoDisponível = value;
                // if (_saldoDisponível >= EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida)
                // {
                //     _montanteCrédito = _saldoDisponível - EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida;
                //     _montanteDívida = 0.0m;
                // }
                // else
                // {
                //     _montanteDívida = EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida - SaldoDisponível;
                //     _montanteCrédito = 0.0m;
                // }
            }
        }

        public decimal MontanteDívida
        {
            get => _montanteDívida;
            set
            {
                _montanteDívida = value;
                if (MontanteCrédito != 0.0m)
                {
                    if (MontanteCrédito >= value)
                    {
                        _montanteDívida = 0.0m;
                        MontanteCrédito -= value;
                    }
                    else
                    {
                        _montanteDívida -= MontanteCrédito;
                        MontanteCrédito = 0.0m;
                    }
                }
                else
                {
                    if (SaldoDisponível != 0.0m)
                    {
                        if (SaldoDisponível >= value)
                        {
                            _montanteDívida = 0.0m;
                            SaldoDisponível -= value;
                        }
                        else
                        {
                            value -= SaldoDisponível;
                            SaldoDisponível = 0.0m;
                            _montanteDívida = value;
                        }
                    }
                    else
                    {
                        _montanteDívida = value;
                    }
                }
            }
        }

        public decimal MontanteCrédito
        {
            get => _montanteCrédito;
            set
            {
                _montanteCrédito = value;
                if (MontanteDívida != 0.0m)
                {
                    if (MontanteDívida >= value)
                    {
                        _montanteCrédito = 0.0m;
                        MontanteDívida -= value;
                    }
                    else
                    {
                        _montanteCrédito -= MontanteDívida;
                        MontanteDívida = 0.0m;
                    }
                }
                else
                {
                    _montanteCrédito = value;
                }

                if (SaldoDisponível < EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida &&
                    MontanteDívida == 0.0m)
                {
                    if (_montanteCrédito >= EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida -
                        SaldoDisponível)
                    {
                        _montanteCrédito -= EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida -
                                            SaldoDisponível;
                        SaldoDisponível = EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida;
                    }
                    else
                    {
                        SaldoDisponível += _montanteCrédito;
                        _montanteCrédito = 0.0m;
                    }
                }
            }
        }

        public decimal EnergiaTotalProduzida { get; set; }

        public decimal EnergiaTotalTransferida { get; set; }

        public decimal EnergiaTotalRecebida { get; set; }
    }
}