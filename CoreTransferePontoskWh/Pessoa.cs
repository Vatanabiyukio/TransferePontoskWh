using System.Collections.Generic;

namespace CoreTransferePontoskWh
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public List<Base> Bases { get; set; }
    }
}