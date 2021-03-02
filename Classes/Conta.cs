using System;

namespace DIO.Bank
{
    public class Conta
    {
         private string  Nome { get; set; }
        
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double  Credito { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
               
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é 'R$'{1} ", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {    
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é 'R$'{1} ", this.Nome, this.Saldo);           
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);              
            }
        }

        public override string ToString()
        {
            string retorno ="";
            retorno += " TipoConta:" + this.TipoConta +  " \n " ;
            retorno += "Nome do Correntista:" + this.Nome +  " \n " ;
            retorno += "Saldo:R$" + this.Saldo +  " \n " ;
            retorno += "Crédito:" + this.Credito +  " \n " ;

            return retorno;
        }
    }
}