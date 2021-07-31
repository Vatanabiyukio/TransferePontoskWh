using System.Collections.Generic;

namespace CoreTransferePontoskWh
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica(string nome, string cpf, string email, string celular)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Celular = celular;
            Bases = new List<Base>();
            Lista.AdicionarListaPessoaFisica(this);
        }

        public string Cpf { get; set; }
    }
}