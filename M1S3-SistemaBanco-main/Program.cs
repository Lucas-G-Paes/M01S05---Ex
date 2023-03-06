using System.Globalization;
using M1S3_SistemaBanco;

ClienteService.clientes.Add(new PessoaFisica("Vitor", "123456", new DateTime(2002, 5, 15),"123", "rua","vitor@email", 1));
            
/*clientes.Add(new Cliente("Fernando", "123456", "Fernando@email","123", "rua",new DateTime(2002, 5, 15), 2));
            
clientes.Add(new Cliente("Vanessa", "123456", "Vanessa@email","123", "rua",new DateTime(2002, 5, 15), 3));

clientes.Add(new Cliente("Lucas", "123456", "Lucas@email","123", "rua",new DateTime(2002, 5, 15), 4));*/



string opcao;

ClienteService clienteService = new ClienteService();

do
{
  Console.WriteLine("Bem vindos ao Banco FULL STACK BANCK, escolha uma opção");
  Console.WriteLine("1 - Criar Conta ");
  Console.WriteLine("2 - Adicionar Transacao");
  Console.WriteLine("3 - Consultar Extrato");
  Console.WriteLine("4 - Exibir Clientes");
  Console.WriteLine("5 - Sair");
  opcao = Console.ReadLine();

  if(opcao == "1")
  {
    Console.WriteLine("Qual conta você deseja criar.");
    Console.WriteLine("1 - Criar Conta Pessoa Fisica.");
    Console.WriteLine("2 - Criar Conta Pessoa Juridica.");
    string tipoConta = Console.ReadLine();
    clienteService.CriarConta(tipoConta);
  }
  else if (opcao == "4")
  {
    clienteService.ExibirClientes();
  }
  else if (opcao == "2")
  {
    AdicionarTransacao();
  }
  else if (opcao == "3")
  {
    ExibirExtrato();
  }

  Console.WriteLine("Tecle Enter para continuar");
  Console.ReadLine();
} while(opcao != "5");




void AdicionarTransacao()
{
  Console.WriteLine("Qual a conta?");
  int numeroConta = int.Parse(Console.ReadLine());

  Cliente contaCliente = clienteService.BuscarClientePorNumeroDeConta(numeroConta);

  if (contaCliente == null)
  {
    Console.WriteLine("Conta não cadastrada, favor cadastrar antes");
    return;
  }

  Console.WriteLine("Qual o valor da transação?" );
  double valor = double.Parse(Console.ReadLine());
  Transacao transacao = new Transacao(DateTime.Now, valor);

  contaCliente.Extrato.Add(transacao);

}

void ExibirExtrato()
{
  Console.WriteLine("Qual a conta?");
  int numeroConta = int.Parse(Console.ReadLine());

  Cliente contaCliente = clienteService.BuscarClientePorNumeroDeConta(numeroConta);

  if (contaCliente == null)
  {
    Console.WriteLine("Conta não cadastrada, favor cadastrar antes");
    return;
  }
  double saldo = 0;
  foreach(Transacao transacao  in contaCliente.Extrato)
  {
    Console.WriteLine(" Data: " + transacao.Data + " Valor: " + transacao.Valor.ToString("C2", new CultureInfo("pt-BR")) );
    saldo += transacao.Valor;
    //Console.WriteLine($"Data: {transacao.Data} Valor: R$  {transacao.Valor}" );
  }

  Console.WriteLine("Saldo = " + contaCliente.Saldo);

}
