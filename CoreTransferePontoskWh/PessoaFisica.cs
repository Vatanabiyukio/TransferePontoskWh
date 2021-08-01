using System;
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

        public void Apresentar()
        {
            Console.WriteLine("=============================");
            Console.WriteLine($"Informações de {Cpf}:");
            Console.WriteLine($"  Nome: {Nome}");
            Console.WriteLine($"  CPF: {Cpf}");
            Console.WriteLine($"  Email: {Email}");
            Console.WriteLine($"  Celular: {Celular}");
            if (Bases.Count == 1)
            {
                Console.WriteLine("Propriedade: ");
                Console.WriteLine("+++++++++++++++++++++++++++++");
                foreach (var pBase in Bases) pBase.Apresentar();
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            else if (Bases.Count > 1)
            {
                Console.WriteLine("Propriedades: ");
                Console.WriteLine("+++++++++++++++++++++++++++++");
                foreach (var pBase in Bases) pBase.Apresentar();
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            else
            {
                Console.WriteLine("=============================");
            }
        }
    }
}