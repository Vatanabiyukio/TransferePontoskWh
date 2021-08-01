using System;
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

        public void Apresentar()
        {
            Console.WriteLine("=============================");
            Console.WriteLine($"Informações de {Cnpj}:");
            Console.WriteLine($"  Nome: {Nome}");
            Console.WriteLine($"  CNPJ: {Cnpj}");
            Console.WriteLine($"  Email: {Email}");
            Console.WriteLine($"  Celular: {Celular}");
            if (Bases.Count == 1)
            {
                Console.WriteLine("Propriedade: ");
                foreach (var pBase in Bases) pBase.Apresentar();
            }
            else if (Bases.Count > 1)
            {
                Console.WriteLine("Propriedades: ");
                foreach (var pBase in Bases) pBase.Apresentar();
            }
            else
            {
                Console.WriteLine("=============================");
            }
        }
    }
}