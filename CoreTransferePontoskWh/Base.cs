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

        public Base(string dono, string endereço, decimal energiaTotalProduzida = 0.0m, decimal energiaTotalTransferida = 0.0m,
            decimal energiaTotalRecebida = 0.0m)
        {
            Dono = dono;
            Endereço = endereço;
            _energiaTotalProduzida = energiaTotalProduzida;
            _energiaTotalTransferida = energiaTotalTransferida;
            _energiaTotalRecebida = energiaTotalRecebida;
            _saldoDisponível = CapacidadeTotal;
            Lista.AdicionarListaBase(this);
        }
        public string Dono { get; set; }
        public string Endereço { get; set; }

        public decimal CapacidadeTotal => EnergiaTotalProduzida + EnergiaTotalRecebida - EnergiaTotalTransferida;

        public decimal SaldoDisponível
        {
            get => _saldoDisponível;
            set
            {
                if (MontanteDívida != 0.0m)
                {
                    if (MontanteCrédito != 0.0m)
                    {
                        if (MontanteCrédito >= MontanteDívida)
                        {
                            MontanteCrédito -= _montanteDívida;
                            _montanteDívida = 0;
                            if (SaldoDisponível == CapacidadeTotal)
                            {
                                MontanteCrédito = value;
                            }
                            else
                            {
                                if (SaldoDisponível <= CapacidadeTotal)
                                {
                                    if (SaldoDisponível + value <= CapacidadeTotal)
                                    {
                                        _saldoDisponível += value;
                                    }
                                    else
                                    {
                                        MontanteCrédito = CapacidadeTotal - SaldoDisponível + value;
                                        _saldoDisponível = CapacidadeTotal;
                                    }
                                }
                                else
                                {
                                    MontanteCrédito = (SaldoDisponível - CapacidadeTotal) + value;
                                    _saldoDisponível = CapacidadeTotal;
                                }
                            }
                        }
                        else
                        {
                            MontanteDívida -= MontanteCrédito;
                            _montanteCrédito = 0;
                            if (SaldoDisponível >= MontanteDívida)
                            {
                                _saldoDisponível -= MontanteDívida;
                                _montanteDívida = 0;
                                if (SaldoDisponível == CapacidadeTotal)
                                {
                                    MontanteCrédito = value;
                                }
                                else
                                {
                                    if (SaldoDisponível <= CapacidadeTotal)
                                    {
                                        if (SaldoDisponível + value <= CapacidadeTotal)
                                        {
                                            _saldoDisponível += value;
                                        }
                                        else
                                        {
                                            MontanteCrédito = CapacidadeTotal - SaldoDisponível + value;
                                            _saldoDisponível = CapacidadeTotal;
                                        }
                                    }
                                    else
                                    {
                                        MontanteCrédito = (SaldoDisponível - CapacidadeTotal) + value;
                                        _saldoDisponível = CapacidadeTotal;
                                    }
                                }
                            }
                            else
                            {
                                MontanteDívida -= SaldoDisponível;
                                _saldoDisponível = 0;
                                if (MontanteDívida <= value)
                                {
                                    value -= MontanteDívida;
                                    _montanteDívida = 0;
                                    _saldoDisponível = value;
                                }
                                else
                                {
                                    MontanteDívida -= value;
                                    value = 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (SaldoDisponível == CapacidadeTotal)
                    {
                        MontanteCrédito = value;
                    }
                    else
                    {
                        if (SaldoDisponível <= CapacidadeTotal)
                        {
                            if (SaldoDisponível + value <= CapacidadeTotal)
                            {
                                _saldoDisponível += value;
                            }
                            else
                            {
                                MontanteCrédito = CapacidadeTotal - SaldoDisponível + value;
                                _saldoDisponível = CapacidadeTotal;
                            }
                        }
                        else
                        {
                            MontanteCrédito = (SaldoDisponível - CapacidadeTotal) + value;
                            _saldoDisponível = CapacidadeTotal;
                        }
                    }
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

        public decimal EnergiaTotalProduzida
        {
            get => _energiaTotalProduzida;
            set
            {
                var temp = _energiaTotalProduzida;
                _energiaTotalProduzida = value;
                SaldoDisponível = value - temp;
            }
        }

        public decimal EnergiaTotalTransferida
        {
            get => _energiaTotalTransferida;
            set
            {
                var temp = _energiaTotalTransferida;
                _energiaTotalTransferida = value;
                SaldoDisponível = temp - value;
            }
        }

        public decimal EnergiaTotalRecebida
        {
            get => _energiaTotalRecebida;
            set
            {
                var temp = _energiaTotalRecebida;
                _energiaTotalRecebida = value;
                SaldoDisponível = value - temp;
            }
        }
    }
}