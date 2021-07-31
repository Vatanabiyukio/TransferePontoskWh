using System.Collections.Generic;

namespace CoreTransferePontoskWh
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica(string nome, string cnpj, string email, string celular)
        {
            Nome = nome;
            Cnpj = cnpj;
            Email = email;
            Celular = celular;
            Bases = new List<Base>();
            Lista.AdicionarListaPessoaJuridica(this);
        }

        public string Cnpj { get; set; }
    }
}