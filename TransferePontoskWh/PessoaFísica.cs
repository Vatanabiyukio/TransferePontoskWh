namespace TransferePontoskWh
{
    public class PessoaFísica : Pessoa
    {
        private string Cpf { get; set; }

        public PessoaFísica(string nome, string cpf, string email, string celular, string endereço)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Celular = celular;
            this.Endereço = endereço;
        }
        
    }
}