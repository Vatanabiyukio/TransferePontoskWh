using System;
using System.Collections.Generic;

namespace CoreTransferePontoskWh
{
    public static class Lista
    {
        public static List<PessoaFísica> ListaPessoaFísica = new();
        public static List<PessoaJurídica> ListaPessoaJurídica = new();
        public static List<Base> ListaBase = new();

        public static int PesquisarListaPessoaFísica(string cpf)
        {
            var i = 0;
            foreach (var p in ListaPessoaFísica)
            {
                if (p.Cpf == cpf) return i;
                i += 1;
            }

            return -1;
        }

        public static int PesquisarListaPessoaJurídica(string cnpj)
        {
            var j = 0;
            foreach (var p in ListaPessoaJurídica)
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

        public static bool AdicionarListaPessoaFísica(PessoaFísica p)
        {
            if (ListaPessoaFísica.Contains(p)) return false;
            if (PesquisarListaPessoaFísica(p.Cpf) != -1) return false;
            ListaPessoaFísica.Add(p);
            return true;
        }

        public static bool AdicionarListaPessoaJurídica(PessoaJurídica p)
        {
            if (ListaPessoaJurídica.Contains(p)) return false;
            if (PesquisarListaPessoaJurídica(p.Cnpj) != -1) return false;
            ListaPessoaJurídica.Add(p);
            return true;
        }

        public static bool AdicionarListaBase(Base b)
        {
            if (ListaBase.Contains(b)) return false;
            if (PesquisarListaBase(b.Endereço) != -1) return false;
            ListaBase.Add(b);
            return true;
        }

        public static void ListarListaPessoaFísica()
        {
            foreach (var p in ListaPessoaFísica) Console.WriteLine(p.Cpf);
        }

        public static void ListarListaPessoaJurídica()
        {
            foreach (var p in ListaPessoaJurídica) Console.WriteLine(p.Cnpj);
        }

        public static void ListarListaBase()
        {
            foreach (var b in ListaBase) Console.WriteLine(b.Endereço);
        }

        public static bool RemoverListaPessoaFísica(string cpf)
        {
            var index = PesquisarListaPessoaFísica(cpf);
            if (index == -1) return false;
            ListaPessoaFísica.RemoveAt(index);
            return true;
        }

        public static bool RemoverListaPessoaJurídica(string cnpj)
        {
            var index = PesquisarListaPessoaJurídica(cnpj);
            if (index == -1) return false;
            ListaPessoaJurídica.RemoveAt(index);
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