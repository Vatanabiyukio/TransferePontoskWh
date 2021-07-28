using System;

namespace TransferePontoskWh
{
    public abstract class Pessoa
    {
        private protected string Nome { get; set; }
        private protected string Email { get; set; }
        private protected string Celular { get; set; }
        private protected string Endereço { get; set; }
    }
}