namespace Bank.Account
{
    public class Conta
    {
        private static int TotalDeContas;
        private TipoConta TipoDeConta {get; set;}
        private string Nome {get; set; }
        private double Credito {get; set; }
        private double Saldo {get; set; }
        public int Id{get;}

        public Conta(string Nome, double Credito, double Saldo, TipoConta TipoConta) 
        {
            this.Nome = Nome;
            this.Credito = Credito;
            this.Saldo = Saldo;
            this.TipoDeConta = TipoConta;

            TotalDeContas += 1;
            this.Id = TotalDeContas;
        }

        public void Sacar(double valorSaque)
        {
            if(this.Saldo < valorSaque) 
            {
                throw new System.Exception("Valor da conta não bate !");
            }

            this.Saldo -= valorSaque;
        }

        public void Depositar(double valorDeposito) 
        {
            this.Saldo += valorDeposito;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {            
            this.Sacar(valorTransferencia);
            contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            return string.Concat(
                "\n",
                "Tipo Conta = ", 
                this.TipoDeConta, 
                "\n",
                "ID = ",
                this.Id,
                "\n", 
                "Nome = ", 
                this.Nome,
                "\n",
                "Saldo = ",
                this.Saldo,
                "\n",
                "Credito = ",
                this.Credito
            );
        }
    }
}