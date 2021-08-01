using System;

namespace CoreTransferePontoskWh
{
    public class Operacoes
    {
        public static bool TransferirEnergia()
        {
            if (Lista.ListaBase.Count < 2)
            {
                Console.WriteLine(
                    "[!] Desculpe, é necessário que haja, ao menos, 2 bases cadastradas para realizar tal operação");
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

            Console.WriteLine("[*] Por favor, insira o endereço da base de destino:");
            var endereçoDestino = Console.ReadLine();
            if (Lista.PesquisarListaBase(endereçoDestino) != -1)
            {
                if (endereçoOrigem == endereçoDestino)
                {
                    Console.WriteLine("[x] O remetente e o destinatário são os mesmos!");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }

                Console.WriteLine($"[√] Endereço \"{endereçoDestino}\" encontrado!");
            }
            else
            {
                Console.WriteLine($"[x] Endereço \"{endereçoDestino}\" não encontrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            Console.WriteLine($"[!] Transferência: \"{endereçoOrigem}\" -> \"{endereçoDestino}\"");
            Console.WriteLine("[*] Por favor, insira o valor para transferência:");
            var valor = decimal.Parse(Console.ReadLine()!);
            if (Lista.ListaBase[Lista.PesquisarListaBase(endereçoOrigem)].CapacidadeTotal >= valor)
            {
                Lista.ListaBase[Lista.PesquisarListaBase(endereçoOrigem)].EnergiaTotalTransferida += valor;
                Lista.ListaBase[Lista.PesquisarListaBase(endereçoDestino)].EnergiaTotalRecebida += valor;
                Console.WriteLine("[!] Transferência Bem-Sucedida!");
                return true;
            }

            Console.WriteLine(
                $"[!] Não é possível realizar a transferência com o valor de {valor} kWh. Tente com um valor menor ou igual a {Lista.ListaBase[Lista.PesquisarListaBase(endereçoOrigem)].CapacidadeTotal} kWh");
            Console.WriteLine("[!] Desculpe, operação cancelada!");
            return false;
        }

        public static bool TransferirBase()
        {
            if (Lista.ListaPessoaFisica.Count < 2 && Lista.ListaPessoaJuridica.Count < 2 ||
                Lista.ListaPessoaFisica.Count + Lista.ListaPessoaJuridica.Count < 2)
            {
                Console.WriteLine(
                    "[!] Desculpe, é necessário que haja, ao menos, 2 pessoas cadastradas para realizar tal operação");
                return false;
            }

            Console.WriteLine("[*] Por favor, insira o CPF/CNPJ de origem:");
            var pessoaOrigem = Console.ReadLine();
            if (Lista.PesquisarListaPessoaFisica(pessoaOrigem) == -1 &&
                Lista.PesquisarListaPessoaJuridica(pessoaOrigem) == -1)
            {
                Console.WriteLine($"[!] Pessoa com CPF\\CNPJ \"{pessoaOrigem}\" não encontrada!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            var tipo = true;
            if (Lista.PesquisarListaPessoaFisica(pessoaOrigem) != -1)
            {
                Console.WriteLine($"[√] Pessoa Fisica \"{pessoaOrigem}\" encontrada!");
            }
            else
            {
                Console.WriteLine($"[√] Pessoa Juridica \"{pessoaOrigem}\" encontrada!");
                tipo = false;
            }

            Console.WriteLine("[*] Por favor, insira o endereço da base: ");
            var baseEscolhida = Console.ReadLine();
            if (Lista.PesquisarListaBase(baseEscolhida) != -1)
            {
                Console.WriteLine($"[!] Endereço \"{baseEscolhida}\" encontrado!");
                if (tipo)
                {
                    if (Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(pessoaOrigem)].Cpf !=
                        Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)].Dono)
                    {
                        Console.WriteLine(
                            $"[!] A pessoa fisica \"{pessoaOrigem}\" não é a dona da base em \"{baseEscolhida}\"!");
                        Console.WriteLine("[!] Desculpe, operação cancelada!");
                        return false;
                    }
                }
                else
                {
                    if (Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(pessoaOrigem)].Cnpj !=
                        Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)].Dono)
                    {
                        Console.WriteLine(
                            $"[!] A pessoa juridica \"{pessoaOrigem}\" não é a dona da base em \"{baseEscolhida}\"!");
                        Console.WriteLine("[!] Desculpe, operação cancelada!");
                        return false;
                    }
                }

                Console.WriteLine("[*] Por favor, insira o CPF/CNPJ de destino:");
                var pessoaDestino = Console.ReadLine();
                if (Lista.PesquisarListaPessoaFisica(pessoaOrigem) == -1 &&
                    Lista.PesquisarListaPessoaJuridica(pessoaOrigem) == -1)
                {
                    Console.WriteLine($"[!] Pessoa com CPF\\CNPJ \"{pessoaDestino}\" não encontrada!");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }

                var tipo2 = true;
                if (Lista.PesquisarListaPessoaFisica(pessoaDestino) != -1)
                {
                    Console.WriteLine($"[√] Pessoa Fisica \"{pessoaDestino}\" encontrada!");
                }
                else
                {
                    Console.WriteLine($"[√] Pessoa Juridica \"{pessoaDestino}\" encontrada!");
                    tipo2 = false;
                }

                Console.WriteLine($"[!] Transferir {pessoaOrigem} -> {pessoaDestino}");
                Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)].Dono = pessoaDestino;
                if (tipo2)
                {
                    Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(pessoaOrigem)].Bases
                        .Remove(Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)]);
                    Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(pessoaDestino)].Bases
                        .Add(Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)]);
                }
                else
                {
                    Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(pessoaOrigem)].Bases
                        .Remove(Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)]);
                    Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(pessoaDestino)].Bases
                        .Add(Lista.ListaBase[Lista.PesquisarListaBase(baseEscolhida)]);
                }
            }
            else
            {
                Console.WriteLine($"[x] Endereço \"{baseEscolhida}\" não encontrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            return true;
        }

        public static bool CadastrarPessoaFisica()
        {
            Console.WriteLine("[*] Insira seu CPF:");
            var cpf = Console.ReadLine();
            if (cpf is not {Length: 11})
            {
                Console.WriteLine("[!] A formatação do CPF não é válida, digite apenas os 11 dígitos");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            if (Lista.PesquisarListaPessoaFisica(cpf) != -1)
            {
                Console.WriteLine($"[!] O CPF \"{cpf}\" já está cadastrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            Console.WriteLine("[*] Por favor, informe seu nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("[*] Por favor, informe seu melhor e-mail:");
            var email = Console.ReadLine();
            Console.WriteLine("[*] Por favor, informe 9 dígitos do seu telefone sem DDD:");
            var celular = Console.ReadLine();
            var pessoaFisicaGerada = new PessoaFisica(nome, cpf, email, celular);
            Console.WriteLine($"[√] CPF: \"{pessoaFisicaGerada.Cpf}\" cadastrado com sucesso");
            return true;
        }

        public static bool CadastrarPessoaJuridica()
        {
            Console.WriteLine("[*] Insira seu CNPJ:");
            var cnpj = Console.ReadLine();
            if (cnpj is not {Length: 14})
            {
                Console.WriteLine("[!] A formatação do CNPJ não é válida, digite apenas os 14 dígitos");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            if (Lista.PesquisarListaPessoaJuridica(cnpj) != -1)
            {
                Console.WriteLine($"[!] O CNPJ \"{cnpj}\" já está cadastrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            Console.WriteLine("[*] Por favor, informe seu nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("[*] Por favor, informe seu melhor e-mail:");
            var email = Console.ReadLine();
            Console.WriteLine("[*] Por favor, informe 9 dígitos do seu telefone sem DDD:");
            var celular = Console.ReadLine();
            var pessoaJuridicaGerada = new PessoaJuridica(nome, cnpj, email, celular);
            Console.WriteLine($"[√] CNPJ: \"{pessoaJuridicaGerada.Cnpj}\" cadastrado com sucesso");
            return true;
        }

        public static bool CadastrarBase()
        {
            if (Lista.ListaPessoaFisica.Count == 0 && Lista.ListaPessoaJuridica.Count == 0)
            {
                Console.WriteLine(
                    "[!] Não nenhuma pessoa cadastrada. Por favor, registre alguém para então cadastrar uma base!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            Console.WriteLine("[*] Por favor, insira os dígitos do CPF/CNPJ do dono da propriedade:");
            var donoIdentifação = Console.ReadLine();
            if (donoIdentifação is {Length: 11})
            {
                if (Lista.PesquisarListaPessoaFisica(donoIdentifação) == -1)
                {
                    Console.WriteLine("[!] O CPF não está cadastrado");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }
            }
            else if (donoIdentifação is {Length: 14})
            {
                if (Lista.PesquisarListaPessoaJuridica(donoIdentifação) == -1)
                {
                    Console.WriteLine("[!] O CNPJ não está cadastrado");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("[!] A formatação do CPF/CNPJ não é válida, use apenas os dígitos!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            Console.WriteLine("[*] Por favor, insira o endereço da propriedade:");
            var endereço = Console.ReadLine();
            if (Lista.PesquisarListaBase(endereço) != -1)
            {
                Console.WriteLine("[!] Este endereço já está registrado!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            var baseGerada = new Base(donoIdentifação, endereço);
            if (donoIdentifação is {Length: 11})
                Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(donoIdentifação)].Bases.Add(baseGerada);
            else
                Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(donoIdentifação)].Bases.Add(baseGerada);
            Console.WriteLine($"[√] Nova propriedade em \"{baseGerada.Endereço}\" cadastrada com sucesso");
            return true;
        }

        public static bool DescadastrarPessoa()
        {
            Console.WriteLine("[*] Digite o CPF/CNPJ da pessoa a ser descadastrada:");
            var cpfCnpj = Console.ReadLine();
            if (cpfCnpj is {Length: 11})
            {
                if (Lista.PesquisarListaPessoaFisica(cpfCnpj) == -1)
                {
                    Console.WriteLine("[!] Não é possível descadastrar uma pessoa que nem cadastrada está!");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }

                if (Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(cpfCnpj)].Bases.Count != 0)
                {
                    Console.WriteLine(
                        $"[!] Esta pessoa possui propriedades {Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(cpfCnpj)].Bases.Count}. Portanto, não é possível descadastra-la!");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }

                Lista.ListaPessoaFisica.Remove(Lista.ListaPessoaFisica[Lista.PesquisarListaPessoaFisica(cpfCnpj)]);
                Console.WriteLine($"[√] Pessoa Física \"{cpfCnpj}\" descadastrada com sucesso!");
                return true;
            }

            if (cpfCnpj is {Length: 14})
            {
                if (Lista.PesquisarListaPessoaJuridica(cpfCnpj) == -1)
                {
                    Console.WriteLine("[!] Não é possível descadastrar uma pessoa que nem cadastrada está!");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }

                if (Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(cpfCnpj)].Bases.Count != 0)
                {
                    Console.WriteLine(
                        $"[!] Esta pessoa possui propriedades {Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(cpfCnpj)].Bases.Count}. Portanto, não é possível descadastra-la!");
                    Console.WriteLine("[!] Desculpe, operação cancelada!");
                    return false;
                }

                Lista.ListaPessoaJuridica.Remove(
                    Lista.ListaPessoaJuridica[Lista.PesquisarListaPessoaJuridica(cpfCnpj)]);
                Console.WriteLine($"[√] Pessoa Jurídica \"{cpfCnpj}\" descadastrada com sucesso!");
                return true;
            }

            Console.WriteLine("[!] O CPF/CNPJ digitado não possui formato válido, digite apenas os dígitos!");
            Console.WriteLine("[!] Desculpe, operação cancelada!");
            return false;
        }

        public static bool DescadastrarBase()
        {
            if (Lista.ListaBase.Count == 0)
            {
                Console.WriteLine("[!] Não há nenhuma propriedade cadastrada!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }
            Console.WriteLine("[*] Por favor, insira o endereço da base a ser descadastrada:");
            var endereço = Console.ReadLine();
            if (Lista.PesquisarListaBase(endereço) == -1)
            {
                Console.WriteLine($"[!] A propriedade em \"{endereço}\" não foi encontrada!");
                Console.WriteLine("[!] Desculpe, operação cancelada!");
                return false;
            }

            if (Lista.ListaBase[Lista.PesquisarListaBase(endereço)].Dono is {Length: 11})
            {
                Console.WriteLine(
                    $"[!] A propriedade em \"{endereço}\" foi confiscada da Pessoa Física \"{Lista.ListaBase[Lista.PesquisarListaBase(endereço)].Dono}\"!");
                Lista.ListaPessoaFisica[
                        Lista.PesquisarListaPessoaFisica(Lista.ListaBase[Lista.PesquisarListaBase(endereço)].Dono)]
                    .Bases
                    .Remove(Lista.ListaBase[Lista.PesquisarListaBase(endereço)]);
                Lista.ListaBase.Remove(Lista.ListaBase[Lista.PesquisarListaBase(endereço)]);
            }
            else
            {
                Console.WriteLine(
                    $"[!] A propriedade em \"{endereço}\" foi confiscada da Pessoa Jurídica \"{Lista.ListaBase[Lista.PesquisarListaBase(endereço)].Dono}\"!");
                Lista.ListaPessoaJuridica[
                        Lista.PesquisarListaPessoaJuridica(Lista.ListaBase[Lista.PesquisarListaBase(endereço)].Dono)]
                    .Bases
                    .Remove(Lista.ListaBase[Lista.PesquisarListaBase(endereço)]);
                Lista.ListaBase.Remove(Lista.ListaBase[Lista.PesquisarListaBase(endereço)]);
            }

            Console.WriteLine($"[!] A propriedade em \"{endereço}\" foi descadastrada!");
            return true;
        }
    }
}