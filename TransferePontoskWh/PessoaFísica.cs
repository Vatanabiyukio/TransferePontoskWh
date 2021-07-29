using System.Collections.Generic;

namespace TransferePontoskWh
{
    public class PessoaFísica : Pessoa
    {
        public PessoaFísica(string nome, string cpf, string email, string celular)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Celular = celular;
            Bases = new List<Base>();
            Lista.AdicionarListaPessoaFísica(this);
        }

        public string Cpf { get; set; }
    }
}