namespace TransferePontoskWh
{
    public class PessoaJurídica : Pessoa
    {
        private string Cnpj { get; set; }

        public PessoaJurídica(string nome, string cnpj, string email, string celular, string endereço)
        {
            this.Nome = nome;
            this.Cnpj = cnpj;
            this.Email = email;
            this.Celular = celular;
            this.Endereço = endereço;
        }
    }
}