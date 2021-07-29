namespace TransferePontoskWh
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var amanda = new PessoaFísica("Amanda", "05340723484", "afavelino@gmail.com", "98765428434");
            var tur = new PessoaJurídica("Taberna Tur uh nog", "425321763215673", "turhnogtarberna@gmail.com",
                "887345182");
            var joão = new PessoaFísica("João", "05340723483", "jsavelino@gmail.com", "9284213763");
            var sushi = new PessoaJurídica("Sushi do Zé", "425321725621367", "zesushi@gmail.com", "827128345");
            Lista.ListarListaPessoaFísica();
            Lista.ListarListaPessoaJurídica();
        }
    }
}