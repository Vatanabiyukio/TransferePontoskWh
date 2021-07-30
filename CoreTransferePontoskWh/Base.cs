namespace CoreTransferePontoskWh
{
    public class Base
    {
        private decimal _montanteCrédito;
        private decimal _montanteDívida;
        private decimal _saldoDisponível;
        private decimal _energiaTotalProduzida;
        private decimal _energiaTotalTransferida;
        private decimal _energiaTotalRecebida;

        public Base(string endereço, decimal energiaTotalProduzida = 0.0m, decimal energiaTotalTransferida = 0.0m,
            decimal energiaTotalRecebida = 0.0m)
        {
            Endereço = endereço;
            EnergiaTotalProduzida = energiaTotalProduzida;
            EnergiaTotalTransferida = energiaTotalTransferida;
            EnergiaTotalRecebida = energiaTotalRecebida;
            SaldoDisponível = CapacidadeTotal;
            Lista.AdicionarListaBase(this);
        }

        public string Endereço { get; set; }

        private decimal CapacidadeTotal => EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida;

        public decimal SaldoDisponível
        {
            get => _saldoDisponível;
            set
            {
                _saldoDisponível = value;
                if (_saldoDisponível >= CapacidadeTotal)
                {
                    _montanteCrédito = _saldoDisponível - CapacidadeTotal;
                    _montanteDívida = 0.0m;
                    _saldoDisponível = CapacidadeTotal;
                }
                else
                {
                    _montanteDívida = CapacidadeTotal - SaldoDisponível;
                    _montanteCrédito = 0.0m;
                }
            }
        }

        public decimal MontanteDívida
        {
            get => _montanteDívida;
            set
            {
                if (!(MontanteCrédito == 0.0m && SaldoDisponível == 0.0m)) _montanteDívida = value;
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

                if (_montanteDívida != 0.0m)
                {
                    if (SaldoDisponível != 0.0m)
                    {
                        if (SaldoDisponível >= _montanteDívida)
                        {
                            _saldoDisponível -= _montanteDívida;
                            _montanteDívida = 0.0m;
                        }
                        else
                        {
                            value -= SaldoDisponível;
                            _saldoDisponível = 0.0m;
                            _montanteDívida = value;
                        }
                    }
                    else
                    {
                        _montanteDívida += value;
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
                        _montanteDívida -= value;
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

                if (SaldoDisponível < CapacidadeTotal && MontanteDívida == 0.0m)
                {
                    if (_montanteCrédito >= CapacidadeTotal - SaldoDisponível)
                    {
                        _montanteCrédito -= CapacidadeTotal - SaldoDisponível;
                        _saldoDisponível = CapacidadeTotal;
                    }
                    else
                    {
                        _saldoDisponível += _montanteCrédito;
                        _montanteCrédito = 0.0m;
                    }
                }
            }
        }

        public void AtualizaValoresInternos()
        {
            var diferença = CapacidadeTotal - SaldoDisponível;
            if (diferença >= 0)
            {
                if (MontanteCrédito >= diferença)
                {
                    _montanteCrédito -= diferença;
                }
                // else
                // {
                //     diferença -= _montanteCrédito;
                //     MontanteDívida = diferença;
                // }
            }
            else
            {
                diferença *= -1;
                _saldoDisponível = CapacidadeTotal;
                if (MontanteDívida >= diferença)
                {
                    _montanteDívida -= diferença;
                }
                else
                {
                    diferença -= _montanteDívida;
                    MontanteCrédito = diferença;
                }
            }
        }

        public decimal EnergiaTotalProduzida
        {
            get => _energiaTotalProduzida;
            set
            {
                _energiaTotalProduzida = value;
                AtualizaValoresInternos();
            }
        }

        public decimal EnergiaTotalTransferida
        {
            get => _energiaTotalTransferida;
            set
            {
                _energiaTotalTransferida = value;
                AtualizaValoresInternos();
            }
        }

        public decimal EnergiaTotalRecebida
        {
            get => _energiaTotalRecebida;
            set
            {
                _energiaTotalRecebida = value;
                AtualizaValoresInternos();
            }
        }
    }
}