using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco
{
    public class ClienteService
    {
        public static List<Cliente> clientes = new List<Cliente>();

        public void CriarConta(string tipoConta)
        {

            if(tipoConta == "1")
            {
            PessoaFisica clientePF = new PessoaFisica();
            Console.WriteLine("Data de Nascimento do cliente:");
            clientePF.DataNascimento = DateTime.Parse(Console.ReadLine());
            if(!clientePF.EhMaior())
            {
                Console.WriteLine("não é possivel abrir a conta pois o CLiente é menor de idade");
                return ;
            }
            Console.WriteLine("A idade do cliente é " + clientePF.Idade);
            Console.WriteLine("Nome do cliente:");
            clientePF.Nome = Console.ReadLine();
            Console.WriteLine("CPF do cliente:");
            clientePF.CPF = Console.ReadLine();
            Console.WriteLine("Endereco do cliente:");
            clientePF.Endereco = Console.ReadLine();
            Console.WriteLine("Telefone do cliente:");
            clientePF.Telefone = Console.ReadLine();
            Console.WriteLine("Email do cliente:");
            clientePF.Email = Console.ReadLine();
            Console.WriteLine("Numero Da Conta");
            clientePF.NumeroConta = int.Parse(Console.ReadLine());
            ClienteService.clientes.Add(clientePF);
            }
                else if(tipoConta == "2")
            {
            PessoaJuridica clientePJ = new PessoaJuridica();
            Console.WriteLine("Razão Social:");
            clientePJ.RazaoSocial = Console.ReadLine();
            Console.WriteLine("CNPJ do cliente:");
            clientePJ.CNPJ = Console.ReadLine();
            Console.WriteLine("Endereco do cliente:");
            clientePJ.Endereco = Console.ReadLine();
            Console.WriteLine("Telefone do cliente:");
            clientePJ.Telefone = Console.ReadLine();
            Console.WriteLine("Email do cliente:");
            clientePJ.Email = Console.ReadLine();
            Console.WriteLine("Numero Da Conta");
            clientePJ.NumeroConta = int.Parse(Console.ReadLine());
            ClienteService.clientes.Add(clientePJ);
            }
        }
        public Cliente BuscarClientePorNumeroDeConta (int numeroConta)
        { 
            foreach(Cliente cliente in ClienteService.clientes)
            {
                if(cliente.NumeroConta == numeroConta)
                {
                    return cliente;
                }
            }
            return null;
        }

        public void ExibirClientes()
        {
            Console.WriteLine("Número da conta        | Nome         | CPF    ");
            for(int i =0; i < ClienteService.clientes.Count; i++)
            {
                Console.WriteLine(ClienteService.clientes[i].ResumoCliente());
            }
        }
    }
}