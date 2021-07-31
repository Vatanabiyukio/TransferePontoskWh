using System;
using System.Collections.Generic;

namespace CoreTransferePontoskWh
{
    public static class Lista
    {
        public static List<PessoaFisica> ListaPessoaFisica = new();
        public static List<PessoaJuridica> ListaPessoaJuridica = new();
        public static List<Base> ListaBase = new();

        public static int PesquisarListaPessoaFisica(string cpf)
        {
            var i = 0;
            foreach (var p in ListaPessoaFisica)
            {
                if (p.Cpf == cpf) return i;
                i += 1;
            }

            return -1;
        }

        public static int PesquisarListaPessoaJuridica(string cnpj)
        {
            var j = 0;
            foreach (var p in ListaPessoaJuridica)
            {
                if (p.Cnpj == cnpj) return j;
                j += 1;
            }

            return -1;
        }

        public static int PesquisarListaBase(string endereço)
        {
            var k = 0;
            foreach (var b in ListaBase)
            {
                if (b.Endereço == endereço) return k;
                k += 1;
            }

            return -1;
        }

        public static bool AdicionarListaPessoaFisica(PessoaFisica p)
        {
            if (ListaPessoaFisica.Contains(p)) return false;
            if (PesquisarListaPessoaFisica(p.Cpf) != -1) return false;
            ListaPessoaFisica.Add(p);
            return true;
        }

        public static bool AdicionarListaPessoaJuridica(PessoaJuridica p)
        {
            if (ListaPessoaJuridica.Contains(p)) return false;
            if (PesquisarListaPessoaJuridica(p.Cnpj) != -1) return false;
            ListaPessoaJuridica.Add(p);
            return true;
        }

        public static bool AdicionarListaBase(Base b)
        {
            if (ListaBase.Contains(b)) return false;
            if (PesquisarListaBase(b.Endereço) != -1) return false;
            ListaBase.Add(b);
            return true;
        }

        public static void ListarListaPessoaFisica()
        {
            foreach (var p in ListaPessoaFisica) Console.WriteLine(p.Cpf);
        }

        public static void ListarListaPessoaJuridica()
        {
            foreach (var p in ListaPessoaJuridica) Console.WriteLine(p.Cnpj);
        }

        public static void ListarListaBase()
        {
            foreach (var b in ListaBase) Console.WriteLine(b.Endereço);
        }

        public static bool RemoverListaPessoaFisica(string cpf)
        {
            var index = PesquisarListaPessoaFisica(cpf);
            if (index == -1) return false;
            ListaPessoaFisica.RemoveAt(index);
            return true;
        }

        public static bool RemoverListaPessoaJuridica(string cnpj)
        {
            var index = PesquisarListaPessoaJuridica(cnpj);
            if (index == -1) return false;
            ListaPessoaJuridica.RemoveAt(index);
            return true;
        }

        public static bool RemoverListaBase(string endereço)
        {
            var index = PesquisarListaBase(endereço);
            if (index == -1) return false;
            ListaBase.RemoveAt(index);
            return true;
        }
    }
}