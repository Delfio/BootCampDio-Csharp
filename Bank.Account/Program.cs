using System; 
using System.Collections.Generic;

namespace Bank.Account
{
    class minhaClasse {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args) { 
            // Console.BackgroundColor = System.ConsoleColor.Blue;
            Conta minhaConta = new Conta("delfio francisco", 25, 150, TipoConta.PessoaFisica);

            int opcaoDesejada = OberOpcaoDoUsuario();

            while (true)
            {
                switch (opcaoDesejada)
                {
                    case 1: 
                        ListarContas();
                        break;
                    case 2:
                        inserirConta();
                        break;
                    case 3:
                        trasferir();
                        break;
                    case 4:
                        Depositar();
                        break;
                    case 5:
                        Sacar();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                // Console.Clear();
                opcaoDesejada = OberOpcaoDoUsuario();

                if(opcaoDesejada == 7)
                {
                    break;
                }
            }
            Console.WriteLine("Até breve ! :)");
        }

        private static int OberOpcaoDoUsuario()
        {
            string[,] arrDeOpcoes = {
                {"1", "Listar Contas"},
                {"2", "Inserir Nova Conta"},
                {"3", "Transferir"},
                {"4", "Depositar"},
                {"5", "Sacar"},
                {"6", "Limpar Tela"},
                {"7", "Sair"}
            };


            Console.WriteLine();
            Console.WriteLine("DDD Bank ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");

            for (int i = 0; i < arrDeOpcoes.Length /2 ; i++)
            {
                Console.WriteLine("[{0}] - {1}", arrDeOpcoes[i,0], arrDeOpcoes[i,1]);
            }

            return Int16.Parse(Console.ReadLine());
        }
        private static void ListarContas() 
        {
            listContas.ForEach(cnt => Console.WriteLine(cnt.ToString()));
        }
        private static Boolean inserirConta()
        {
            Console.WriteLine("Inserir uma nova conta!");
            Console.WriteLine("Escolha um tipo de conta 1 para pessoa Física e 2 para Jurídica");
            int entrada = Int16.Parse(Console.ReadLine());
            
            Func<string, TipoConta,Conta> gerarConta = (nome, tipoDeConta) => {
                return new Conta(nome, 0, 0, tipoDeConta);
            };
            Console.WriteLine("Informe: ");
            Console.Write("Nome do titular: ");
            String nome = Console.ReadLine();
            
            if(nome.Equals("")) 
            {
                return false;
            };

            if(entrada == 1)
            {
                listContas.Add(gerarConta(nome, TipoConta.PessoaFisica));
                return true;
            } else if(entrada == 2)
            {
                listContas.Add(gerarConta(nome, TipoConta.PessoaJuridica));
                return true;
            }

            return false;

        }
        private static Boolean trasferir()
        {
            Console.Write("\nInsira o id da conta do depositante: ");
            int opcao = Int16.Parse(Console.ReadLine());
            Console.Write("\nInsira o id da conta recipiente: ");
            int opcaoContaRecipiente = Int16.Parse(Console.ReadLine());

            try
            {
                Conta contaReferente = listContas.Find(cn => cn.Id == opcao);
                Conta contaRecipiente = listContas.Find(cn => cn.Id == opcaoContaRecipiente);

                Console.Write("\nInsira o valor para transferência: ");
                var valorTransferencia = Double.Parse(Console.ReadLine());

                contaReferente.Transferir(valorTransferencia, contaRecipiente);
            }
            catch (System.Exception)
            {
                return false;
            }
            
            return true;
        }
        private static Boolean Depositar() 
        {
            Console.Write("\nInsira o id da conta recipiente: ");
            int opcao = Int16.Parse(Console.ReadLine());

            try
            {
                Conta contaRecipiente = listContas.Find(cn => cn.Id == opcao);

                Console.Write("\nInsira o valor para deposito: ");
                var valorTransferencia = Double.Parse(Console.ReadLine());

                contaRecipiente.Depositar(valorTransferencia);
            }
            catch (System.Exception)
            {
                return false;
            }
            
            return true;
        }
        private static Boolean Sacar()
        {
            Console.Write("\nInsira o id da conta: ");
            int opcao = Int16.Parse(Console.ReadLine());

            try
            {
                Conta contaRecipiente = listContas.Find(cn => cn.Id == opcao);

                Console.Write("\nInsira o valor para saque: ");
                var valorParaSaque = Double.Parse(Console.ReadLine());

                contaRecipiente.Sacar(valorParaSaque);
            }
            catch (System.Exception)
            {
                return false;
            }
            
            return true;
        }
    
    }
}
