using System;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace CoreTransferePontoskWh
{
    public class Transações
    {
        public static bool TransferirEnergia()
        {
            if (Lista.ListaBase.Count < 2)
            {
                Console.WriteLine("[!] Desculpe, é necessário que haja, ao menos, 2 bases cadastradas para realizar tal operação");
                return false;
            }
            Console.WriteLine("[*] Por favor, insira o endereço da base de origem:");
            var endereçoOrigem = Console.ReadLine();
            if (Lista.PesquisarListaBase(endereçoOrigem) != -1)
            {
                Console.WriteLine($"[√] Endereço \"{endereçoOrigem}\" encontrado!");
            }
            else
            { 
                Console.WriteLine($"[x] Endereço \"{endereçoOrigem}\" não encontrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }
            Console.WriteLine("[*] Por favor, insira o endereço da base de origem:");
            var endereçoDestino = Console.ReadLine();
            if (Lista.PesquisarListaBase(endereçoDestino) != -1)
            {
                Console.WriteLine($"[√] Endereço \"{endereçoDestino}\" encontrado!");
            }
            else
            { 
                Console.WriteLine($"[x] Endereço \"{endereçoDestino}\" não encontrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }
            Console.WriteLine($"[!] Transferência: \"{endereçoOrigem}\" -> \"{endereçoDestino}\"");
            Console.WriteLine("Por favor, insira o valor para transferência:");
            var valor = decimal.Parse(Console.ReadLine()!);
            if (Lista.ListaBase[Lista.PesquisarListaBase(endereçoOrigem)].CapacidadeTotal >= valor)
            {
                Lista.ListaBase[Lista.PesquisarListaBase(endereçoOrigem)].EnergiaTotalTransferida += valor;
                Lista.ListaBase[Lista.PesquisarListaBase(endereçoDestino)].EnergiaTotalRecebida += valor;
                Console.WriteLine("[!] Transferência Bem-Sucedida!");
                return true;
            }
            Console.WriteLine($"[!] Não é possível realizar a transferência com o valor de {valor} kWh. Tente com um valor menor ou igual a {Lista.ListaBase[Lista.PesquisarListaBase(endereçoOrigem)].CapacidadeTotal} kWh");
            Console.WriteLine("[!] Desculpe, operação cancelada!");
            return false;
        }

        public static bool TransferirBase()
        {
            return true;
        }

        public static bool CadastrarPessoaFísica()
        {
            return true;
        }

        public static bool CadastrarPessoaJurídica()
        {
            return true;
        }

        public static bool CadastrarBase()
        {
            return true;
        }
    }
}