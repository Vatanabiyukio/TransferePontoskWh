using System.Collections.Generic;

namespace TransferePontoskWh
{
    public class PessoaJurídica : Pessoa
    {
        public PessoaJurídica(string nome, string cnpj, string email, string celular)
        {
            Nome = nome;
            Cnpj = cnpj;
            Email = email;
            Celular = celular;
            Bases = new List<Base>();
            Lista.AdicionarListaPessoaJurídica(this);
        }

        public string Cnpj { get; set; }
    }
}